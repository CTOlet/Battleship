using System;
using Newtonsoft.Json;

namespace Classes
{
    public class User
    {
        public int id;
        public string name;
        public string password;
        public int wins;
        public int losses;
        public int rating;
        public DateTime lastActivity;
        public string ip;

        public User()
        {
            id = 0;
            name = null;
            password = null;
            wins = 0;
            losses = 0;
            rating = 0;
            lastActivity = new DateTime();
            ip = null;
        }

        public User(int id, string name, string password, int wins, int losses, int rating, DateTime lastActivity, string ip)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.wins = wins;
            this.losses = losses;
            this.rating = rating;
            this.lastActivity = lastActivity;
            this.ip = ip;
        }

        public User(string json)
        {
            var user = JsonConvert.DeserializeObject<User>(json);
            id = user.id;
            name = user.name;
            password = user.password;
            wins = user.wins;
            losses = user.losses;
            rating = user.rating;
            lastActivity = user.lastActivity;
            ip = user.ip;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
