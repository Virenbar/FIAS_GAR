﻿using FIASUpdate.Properties;

namespace FIASUpdate
{
    internal class FIASProperties
    {
        public static string DBName => Settings.Default.DBName;
        public static string GAR_Delta => $@"{GAR_Common}\gar_delta_xml";
        public static string GAR_Full => $@"{GAR_Common}\gar_xml";
        public static string SQLConnection => Settings.Default.SQLConnection;
        private static string GAR_Common => Settings.Default.XMLPath;
    }
}