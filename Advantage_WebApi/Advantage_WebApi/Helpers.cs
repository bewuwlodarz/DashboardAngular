using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advantage_WebApi
{
    public class Helpers
    {
        private static Random _rand = new Random();
        private static string GetRandom(IList<string> items)
        {
            return items[_rand.Next(items.Count)];

        }

        internal static string MakeUniqueCustomerName(List<string> names)
        {
            var maxNames = bizPrefix.Count * bizSufix.Count;
            if(names.Count>=maxNames)
            {
                throw new System.InvalidOperationException("maximum number of unique names");
            }
            var prefix = GetRandom(bizPrefix);
            var suffix = GetRandom(bizSufix);

            var bizName = prefix + suffix;
            if (names.Contains(bizName))
            {
                MakeUniqueCustomerName(names);
            }
            

            return bizName;

        }
        private static readonly List<string> bizPrefix = new List<string>()
        {
            "Bar",
            "Wer",
            "Pol",
            "Pio",
            "Al",
            "Kin",
            "Ela",
            "Mat",
            "Caisson",
            "Poczt"



        };
        private static readonly List<string> bizSufix= new List<string>()
        {
            "Elektronik",
            "Pol",
            "Ex",
            "Co",
            "Spolka",
            "Firma",
            "Com",
            "Corporation",
            "Tex",
            "Ol"



        };
        internal static string MakeCustomerEmail(string customerName)
        {
            return $"contact@{customerName.ToLower()}.com";

        }

        internal static string GetRandomState()
        {
            return GetRandom(PLStates);
        }
        private static readonly List<string> PLStates = new List<string>()
        {
            "DSL", "KP", "LBL", "LBU","LDZ", "MAZ", "MLP", "OPO", "PDL", "PKR", "POM", "SL", "Sw", "WLKP", "WM", "ZPM"

        };

        internal static decimal GetRandomOrderTotal()
        {
            return _rand.Next(100, 5000);
        }
        internal static DateTime GetRandomOrderPlaced()
        {
            var end = DateTime.Now;
            var start = end.AddDays(-90);
            TimeSpan possibleSpan = end - start;
            TimeSpan newSpan = new TimeSpan(0, _rand.Next(0, (int)possibleSpan.TotalMinutes),0);
            return start + newSpan;
        }

        internal static DateTime? GetRandomOrderCompleted(DateTime orderPlaced)
        {
            var now = DateTime.Now;
            var minLeadTime=TimeSpan.FromDays(7);
            var timePassed = now - orderPlaced;
            if(timePassed<minLeadTime)
            { return null; }
            return orderPlaced.AddDays(_rand.Next(7, 14));

        }
    }
}


