using System;
using System.Data;

namespace Classes
{
    public class UserDAO
    {
        public static User Login(string name, string password)
        {
            var db = new DBConnect();

            if (db.OpenConnection())
            {
                var cmd = db.connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM User WHERE name='{0}' AND password='{1}'", name, password);

                var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                //reader.ReadAsync();
                if (!reader.Read())
                {
                    return null;
                }
                var user = new User(
                    Convert.ToInt32(reader["id"]),
                    reader["name"].ToString(),
                    reader["password"].ToString(),
                    Convert.ToInt32(reader["wins"]),
                    Convert.ToInt32(reader["losses"]),
                    Convert.ToInt32(reader["rating"]),
                    DateTime.Parse(reader["last_activity"].ToString()),
                    reader["ip"].ToString()
                );

                reader.Close();
                db.CloseConnection();

                return user;
            }

            return null;
        }

        public static User FindByName(string name)
        {
            var db = new DBConnect();

            if (db.OpenConnection())
            {
                var cmd = db.connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM User WHERE name='{0}'", name);

                var reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                //reader.ReadAsync();
                if (!reader.Read())
                {
                    return null;
                }
                var user = new User(
                    Convert.ToInt32(reader["id"]),
                    reader["name"].ToString(),
                    reader["password"].ToString(),
                    Convert.ToInt32(reader["wins"]),
                    Convert.ToInt32(reader["losses"]),
                    Convert.ToInt32(reader["rating"]),
                    DateTime.Parse(reader["last_activity"].ToString()),
                    reader["ip"].ToString()
                );

                reader.Close();
                db.CloseConnection();

                return user;
            }

            return null;
        }

        public static void UpdateUser(User user)
        {
            var db = new DBConnect();

            if (db.OpenConnection())
            {
                var cmd = db.connection.CreateCommand();

                cmd.CommandText = string.Format("UPDATE User SET wins='{0}', losses='{1}', rating='{2}' WHERE name='{3}'", user.wins, user.losses, user.rating, user.name);

                cmd.ExecuteNonQuery();

                db.CloseConnection();
            }
        }
    }
}
