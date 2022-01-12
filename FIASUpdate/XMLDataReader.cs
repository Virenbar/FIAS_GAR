using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;

namespace FIASUpdate
{
    internal class XMLDataReader : IDataReader
    {
        protected readonly List<string> AttributeNames;
        protected readonly Dictionary<string, string> CurrentAttributes = new Dictionary<string, string>();
        protected readonly Dictionary<string, int> Mapping;
        protected readonly XmlReader XML;

        protected XMLDataReader(string File)
        {
            XML = XmlReader.Create("file:////" + File);
        }

        public XMLDataReader(string File, IEnumerable<string> AttributeNames) : this(File)
        {
            this.AttributeNames = AttributeNames.ToList();
            var index = 0;
            Mapping = AttributeNames.ToDictionary(K => K, V => index++);
        }

        public int FieldCount => AttributeNames.Count;

        public object this[int i] => CurrentAttributes[AttributeNames[i]];

        public object this[string name] => CurrentAttributes[name];

        public int GetOrdinal(string name) => Mapping[name];

        public object GetValue(int i) => this[i];

        public bool IsDBNull(int i) => this[i] == null;

        public bool Read()
        {
            while (XML.Read())
            {
                if (IsValidRow())
                {
                    CurrentAttributes.Clear();
                    foreach (var Name in AttributeNames)
                    {
                        CurrentAttributes[Name] = GetAttribute(Name);
                    }
                    return true;
                }
            }
            return false;
        }

        protected virtual string GetAttribute(string name) => XML.GetAttribute(name);

        protected virtual bool IsValidRow()
        {
            return XML.HasAttributes && AttributeNames.Any((name) => XML.GetAttribute(name) != null);
        }

        #region IDisposable Support
        private bool disposedValue;

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    AttributeNames.Clear();
                    CurrentAttributes.Clear();
                    Mapping.Clear();
                    XML.Dispose();
                }
                disposedValue = true;
            }
        }

        #endregion IDisposable Support

        #region NotImplemented
        public int Depth => throw new NotImplementedException();

        public bool IsClosed => throw new NotImplementedException();

        public int RecordsAffected => throw new NotImplementedException();

        public void Close() => throw new NotImplementedException();

        public bool GetBoolean(int i) => throw new NotImplementedException();

        public byte GetByte(int i) => throw new NotImplementedException();

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length) => throw new NotImplementedException();

        public char GetChar(int i) => throw new NotImplementedException();

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length) => throw new NotImplementedException();

        public IDataReader GetData(int i) => throw new NotImplementedException();

        public string GetDataTypeName(int i) => throw new NotImplementedException();

        public DateTime GetDateTime(int i) => throw new NotImplementedException();

        public decimal GetDecimal(int i) => throw new NotImplementedException();

        public double GetDouble(int i) => throw new NotImplementedException();

        public Type GetFieldType(int i) => throw new NotImplementedException();

        public float GetFloat(int i) => throw new NotImplementedException();

        public Guid GetGuid(int i) => throw new NotImplementedException();

        public short GetInt16(int i) => throw new NotImplementedException();

        public int GetInt32(int i) => throw new NotImplementedException();

        public long GetInt64(int i) => throw new NotImplementedException();

        public string GetName(int i) => throw new NotImplementedException();

        public DataTable GetSchemaTable() => throw new NotImplementedException();

        public string GetString(int i) => throw new NotImplementedException();

        public int GetValues(object[] values) => throw new NotImplementedException();

        public bool NextResult() => throw new NotImplementedException();

        #endregion NotImplemented
    }
}