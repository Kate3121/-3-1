using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Лр3_1
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            //connection string
            string host = "localhost";
            int port = 3306;
            string database = "payment_for_the_tariff_";
            string username = "andrey";
            string password = "1111";
            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);

        }
    }
}