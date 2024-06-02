using System;
using System.Data.Common;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;

namespace Лр3_1
{
    class Program
    {
        static void Main(string[] args)
        {//Получить объект Connection подключенный к DB.
            Console.WriteLine("Getting Connection...");
            MySqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                Console.WriteLine("Opening Connection...");
                conn.Open();
                Console.WriteLine("Connection successful!");
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //Закрыть соединение
                conn.Close();
                //Уничтожить объект, освободить ресурс
                conn.Dispose();
            }
            Console.Read();
        }
        private static void QueryEmployee(MySqlConnection conn)
        {
            string id, lastname, name, middlename, phone_number, tariff_id;
            string sql = "Select abonent_id, lastname, name, middlename, phone_number, tariff_id from abonent";

            //создать объект Command
            MySqlCommand cmd = new MySqlCommand();

            //сочетать Command c Connection
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {                                     
                   while (reader.Read())
                   {
                        id = reader["abonent_id"].ToString();
                        lastname = reader["lastname"].ToString();
                        name = reader["name"].ToString();
                        middlename = reader["middlename"].ToString();
                        phone_number = reader["phone_number"].ToString();
                        tariff_id = reader["tariff_id"].ToString();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Код:" + id +" Прiзвище:"+ lastname + " Iм'я:"+ name + " По-батьковi:" + 
                            middlename + " Номер телефону:" + phone_number + " Тарифний план:" + tariff_id);
                   }
                    
                }
            }
        }

    }
}