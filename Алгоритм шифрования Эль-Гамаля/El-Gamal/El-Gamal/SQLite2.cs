using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace El_Gamal
{
    class SQLite2
    {
        public static SQLiteConnection GetDBConnection()
        {
            string filename = @"\Диссертация\проект\Алгоритм шифрования Эль-Гамаля\admin.db";
            return SQLite.GetDBConnection(filename);
        }
        
        
    }
}
