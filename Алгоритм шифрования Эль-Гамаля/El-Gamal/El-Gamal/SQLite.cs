using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Gamal
{
    class SQLite
    {
        //static SQLiteConnection connection;
        //public static bool Connect(string fileName)
        //{
        //    try
        //    {
        //        connection = new SQLiteConnection("Data Source=" + fileName + ";");
        //        connection.Open();
        //        return true;
        //    }
        //    catch (SQLiteException ex)
        //    {
        //        MessageBox.Show($"Ошибка доступа к базе данных. Исключение: {ex.Message}");
        //        return false;
        //    }
        //}
        //public int Data()
        //{
        //    if (Connect(@"\Диссертация\проект\Алгоритм шифрования Эль-Гамаля\admin.db"))
        //    {
        //        return 1;
        //    }
        //    else
        //        return 0;
        //}
        public static SQLiteConnection GetDBConnection(string filename)
        {
            String connString = "Data Source = " + filename + ";";
            SQLiteConnection conn = new SQLiteConnection(connString);
            return conn;
        }
    }
}
