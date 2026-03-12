using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace FIASUpdate.Models
{
    /// <summary>
    /// Базовый класс архива ФИАС
    /// </summary>
    internal abstract class FIASArchive
    {
        protected FileInfo Archive;

        protected FIASArchive(string path)
        {
            SetArchivePath(path);
        }

        protected FIASArchive() { }

        /// <summary>
        /// Путь до архива
        /// </summary>
        public string ArchivePath { get; protected set; }

        /// <summary>
        /// Размер архива
        /// </summary>
        public long? ArchiveSize { get; protected set; }

        /// <summary>
        /// Дата (версия) архива
        /// </summary>
        public DateTime Date { get; protected set; }

        /// <summary>
        /// Существует ли архив
        /// </summary>
        public bool Exsists { get; protected set; }

        /// <summary>
        /// Путь для извлечения архива
        /// </summary>
        public abstract string ExtractPath { get; }

        /// <summary>
        /// Извлечь файлы из архива для указанных субъектов
        /// </summary>
        /// <param name="subjects">Перечисление субъектов</param>
        public void Extract(IEnumerable<string> subjects)
        {
            var path = ArchivePath;
            using (var zip = ZipFile.OpenRead(path))
            {
                // Корневые файлы
                var root = zip.Entries.Where(E => !E.FullName.Contains(@"/"));
                // Файлы субъектов
                var files = zip.Entries.Where(E => subjects.Any(S => E.FullName.Contains($@"{S}/")));

                foreach (var item in root.Concat(files))
                {
                    var file = Path.Combine(ExtractPath, item.FullName);
                    Directory.CreateDirectory(Path.GetDirectoryName(file));
                    item.ExtractToFile(file, true);
                }
            }
        }

        /// <summary>
        /// Извлечь дату (версию) архива
        /// </summary>
        public void ExtractVersion()
        {
            Refresh();
            if (!Exsists) { return; }

            var path = ArchivePath;
            using (var zip = ZipFile.OpenRead(path))
            {
                var entry = zip.Entries.First(E => E.FullName.Contains("version.txt"));
                using (var S = entry.Open())
                {
                    using (var SR = new StreamReader(S))
                    {
                        var version = SR.ReadLine();
                        if (DateTime.TryParse(version, out var date))
                        {
                            Date = date;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обновить состояние файла архива
        /// </summary>
        public void Refresh()
        {
            Archive.Refresh();
            Exsists = Archive.Exists && IsValid();
            if (Exsists)
            {
                ArchiveSize = Archive.Length;
            }
        }

        /// <summary>
        /// Проверить корректность архива
        /// </summary>
        protected bool IsValid()
        {
            try
            {
                // Попробовать открыть для проверки целостности
                // Выдаст ошибку если файл в процессе записи или повреждён
                // Может зависнуть на повреждённом архиве
                // Нужна проверка хэша, но увы. Хэш в сделку не входил
                using (var zip = ZipFile.OpenRead(Archive.FullName))
                {
                    return zip.Entries.Count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected void SetArchivePath(string path)
        {
            ArchivePath = path;
            Archive = new FileInfo(ArchivePath);
            Refresh();
        }
    }
}