using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class HistoryDAO
    {
        public static bool Save(String winnerName, String loserName, DateTime date)
        {
            var db = new DBConnect();

            if (db.OpenConnection())
            {
                var cmd = db.connection.CreateCommand();
                cmd.CommandText = string.Format("INSERT INTO `history` (`winner_name`, `loser_name`, `date`) VALUES ('{0}', '{1}', '{2}');", winnerName, loserName, date.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();

                db.CloseConnection();

                return true;
            }

            return false;
        }

        public static List<History> SelectAll()
        {
            var db = new DBConnect();

            var list = new List<History>();
            if (db.OpenConnection())
            {
                var cmd = db.connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM history");

                var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                //reader.ReadAsync();
                while (reader.Read())
                {
                    list.Add(new History(
                        Convert.ToInt32(reader["id"]),
                        reader["winner_name"].ToString(), 
                        reader["loser_name"].ToString(), 
                        DateTime.Parse(reader["date"].ToString())
                    ));
                }

                reader.Close();
                db.CloseConnection();

                return list;
            }

            return list;
        }
    }
}
