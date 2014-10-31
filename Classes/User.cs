using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Classes
{
    [Serializable]
    public class User
    {
        public int Id;
        public string Name;
        public string Password;
        public int Wins;
        public int Defeats;
        public int Rating;
        public DateTime LastActivity;
        public string Ip;

        public User()
        {
            Id = 0;
            Name = null;
            Password = null;
            Wins = 0;
            Defeats = 0;
            Rating = 0;
            LastActivity = new DateTime();
            Ip = null;
        }

        public User(int id, string name, string password, int wins, int defeats, int rating, DateTime lastActivity, string ip)
        {
            Id = id;
            Name = name;
            Password = password;
            Wins = wins;
            Defeats = defeats;
            Rating = rating;
            LastActivity = lastActivity;
            Ip = ip;
        }

        public User(string json)
        {
            var user = JsonConvert.DeserializeObject<User>(json);
            Id = user.Id;
            Name = user.Name;
            Password = user.Password;
            Wins = user.Wins;
            Defeats = user.Defeats;
            Rating = user.Rating;
            LastActivity = user.LastActivity;
            Ip = user.Ip;
        }

        public static User Login(string name, string password)
        {
            var db = new DBConnect();

            if (db.OpenConnection())
            {
                var cmd = db.connection.CreateCommand();
                cmd.CommandText = string.Format("SELECT * FROM user WHERE name='{0}' AND password='{1}'", name, password);

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
                    Convert.ToInt32(reader["defeats"]),
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

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
