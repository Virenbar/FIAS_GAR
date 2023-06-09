using FIAS.Core.Stores;
using FIASUpdate.Models;
using System.Collections.Generic;

namespace FIASUpdate
{
    internal class DBDeltaImport
    {
        private readonly FIASStore Store = new FIASStore(Program.Connection);
        private readonly List<FIASTable> Tables = new List<FIASTable>();

        private static string GAR_Common => Program.XMLPath;
        private static string GAR_Delta => $@"{GAR_Common}\gar_delta_xml";
    }
}