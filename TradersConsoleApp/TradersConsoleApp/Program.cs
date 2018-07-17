using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = new Market();
            for (var y = 0; y < 200; ++y) m.NextYear();

            foreach (var trader in m.OrderByDescending(_ => _.Money))
            {
                Console.WriteLine(trader.Money + ": " + trader.Strategy.GetType().Name);
            }

        }
    }
}
