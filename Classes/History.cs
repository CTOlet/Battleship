using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Classes
{
    public class History
    {
        public int id;
        public string winnerName;
        public string loserName;
        public DateTime date;

        public History(int id, string winnerName, string loserName, DateTime date)
        {
            this.id = id;
            this.winnerName = winnerName;
            this.loserName = loserName;
            this.date = date;
        }

        public static List<History> List(string json)
        {
            var list = JsonConvert.DeserializeObject<List<History>>(json);

            return list;
        }
    }
}
