using System.Data.SqlClient;
using System.Windows.Forms;

namespace FIASUpdate.Models
{
    internal class DBStringLVI : ListViewItem
    {
        private readonly SqlConnectionStringBuilder CSB;

        public DBStringLVI(string connection)
        {
            Connection = connection;
            CSB = new SqlConnectionStringBuilder(connection);
            SubItems[0].Text = Server;
            SubItems.Add(Database);
        }

        public string Connection { get; }
        public string Database => CSB.InitialCatalog;
        public string Server => CSB.DataSource;
    }
}