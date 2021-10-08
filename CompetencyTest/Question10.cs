using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CompetencyTest
{
    class Question10
    {
        public class Record
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string Email { get; set; }
            public string Telephone { get; set; }
        }

        static Question10()
        {
            ConnString = Dns.GetHostName() == "soft" ? MyConnString : UctConnString;
        }

        const string UctConnString = "Data Source=SRVWINSQL001;Initial Catalog=ThirdParty;Persist Security Info=True;User ID=sa;Password=mySecretPassword";
        const string MyConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThirdParty;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static string ConnString { get; }

        private static IList<Record> ReadCsvFile(string filepath, char separator = ',')
        {
            if (File.Exists(filepath) == false)
            {
                Console.WriteLine("File Not Found");
                return null;
            }

            var lines = File.ReadAllLines(filepath);

            var records = new List<Record>();

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                var fields = line.Split(separator);

                //  we expect ONLY 4 fields
                if (fields.Length != 4)
                {
                    Console.WriteLine($"Error in line {i + 1} : {line}");
                    continue;
                }

                var newRecord = new Record();

                for (int j = 0; j < fields.Length; j++)
                {
                    var str = fields[j];

                    if (j == 0)
                        newRecord.LastName = str;
                    else if (j == 1)
                        newRecord.FirstName = str;
                    else if (j == 2)
                        newRecord.Email = str;
                    else if (j == 3)
                        newRecord.Telephone = str;
                }

                if (IsValidRecord(newRecord) == false)
                {
                    Console.WriteLine($"Error in record {i + 1} : {line}");
                    continue;
                }

                records.Add(newRecord);
            }

            return records;
        }

        private static bool IsValidRecord(Record newRecord)
        {
            return newRecord != null &&
                   IsValidName(newRecord.LastName) &&
                   IsValidName(newRecord.FirstName) &&
                   IsValidEmail(newRecord.Email) &&
                   IsValidPhone(newRecord.Telephone);
        }

        private static bool IsValidName(string name)
        {
            //  NOT NULL
            if (name == null)
                return false;

            //  NOT blank
            if (string.IsNullOrWhiteSpace(name))
                return false;

            //  not longer than 255
            if (name.Length > 255)
                return false;

            if (Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z-]+[a-zA-Z]$", RegexOptions.IgnoreCase))
                return true;

            return false;
        }

        private static bool IsValidEmail(string email)
        {
            //  NOT NULL - NOT blank
            if (string.IsNullOrWhiteSpace(email))
                return false;

            //  not longer than 255
            if (email.Length > 255)
                return false;

            const string pattern = @"^[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$";
            return Regex.IsMatch(email.Trim(), pattern, RegexOptions.IgnoreCase);
        }

        private static bool IsValidPhone(string phone)
        {
            //  can be NULL or empty
            if (string.IsNullOrWhiteSpace(phone))
                return true;

            //  not longer than 12 characters
            if (phone.Length > 12)
                return false;

            //  South African Cellular numbers e.g. 0622445633, +27622445633
            if (Regex.IsMatch(phone, @"^(\+27|0)[6-8][0-9]{8}$"))
                return true;

            //  South African Land numbers e.g. 0216501234, +27216501234
            if (Regex.IsMatch(phone, @"^(\+27|0)[1-5][0-9]{8}$"))
                return true;

            ////  Nigerian Numvers
            //if (Regex.IsMatch(phone, @"^0[7-9][0-9]{9}$"))
            //    return true;

            return false;
        }

        public static string Run(string csvPath)
        {
            var list = ReadCsvFile(csvPath);
            InsertRecords(list);
            return $"Extracted {list.Count}";
        }

        private static int GetLastInsertId(SqlConnection connection)
        {
            const string sql1 = "SELECT	MAX(PersonID) FROM [Users]";
            var cmd = new SqlCommand(sql1, connection);
            var lastInsertId = cmd.ExecuteScalar();
            if (lastInsertId == null || lastInsertId == DBNull.Value)
                return 0;

            return Convert.ToInt32(lastInsertId);
        }

        private static void InsertRecords(IList<Record> records)
        {
            var connection = new SqlConnection(ConnString);

            const string sql = "INSERT INTO[Users](PersonID, LastName, FirstName, Email, Telephone) VALUES(@PersonID, @LastName, @FirstName, @Email, @Telephone)";
            connection.Open();

            /*
             * PersonID is not an IDENTITY... we need to provide values during INSERST
             * Determine the Highest Value in the [Users] table and continue
             */

            var lastInsertId = GetLastInsertId(connection);

            var batchSize = 100;

            for (int i = 0; i < records.Count; i += batchSize)
            {
                var pool = records.Skip(i).Take(batchSize).ToList();

                var transaction = connection.BeginTransaction();

                foreach (var p in pool)
                {
                    var cmd = new SqlCommand(sql, connection, transaction);
                    cmd.Parameters.AddWithValue("@PersonID", ++lastInsertId);
                    cmd.Parameters.AddWithValue("@LastName", p.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", p.FirstName);
                    cmd.Parameters.AddWithValue("@Email", p.Email);
                    cmd.Parameters.AddWithValue("@Telephone", p.Telephone);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
        }
    }
}
