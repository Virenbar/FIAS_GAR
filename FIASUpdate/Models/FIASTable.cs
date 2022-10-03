using System;
using System.Collections.Generic;
using System.Linq;

namespace FIASUpdate.Models
{
    internal class FIASTable
    {
        public FIASTable(string name, List<XMLFile> files)
        {
            Name = name;
            Files = files;
            Date = files.Max(F => F.Date);
        }

        public DateTime Date { get; }
        public List<XMLFile> Files { get; }
        public string Name { get; }

        public override string ToString() => $"{{Name={Name},Date={Date}}}";
    }
}