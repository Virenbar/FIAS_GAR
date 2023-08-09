using FIAS.Core.Stores;
using FIASUpdate.Models;
using FIASUpdate.Properties;
using System.Collections.Generic;

namespace FIASUpdate
{
    internal class DBDeltaImport
    {
        private static readonly Settings Settings = Settings.Default;
        private readonly FIASStore Store = new FIASStore(Settings.SQLConnection);
        private readonly List<FIASTable> Tables = new List<FIASTable>();

        private static string GAR_Common => Settings.XMLPath;
        private static string GAR_Delta => $@"{GAR_Common}\gar_delta_xml";
    }
}