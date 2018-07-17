using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TradersConsoleApp.Abstract;
using TradersConsoleApp.Properties;
using TradersConsoleApp.Strategies;

namespace TradersConsoleApp.Infrastructure
{
    public class Market : IEnumerable<Trader>
    {
        private readonly List<Trader> _traders = new List<Trader>();

        public Market()
        {
            for (var idx = 0; idx < Settings.Default.TraderNumber; idx++)
            {
                _traders.Add(new Trader(new AltruistStategy()));
                _traders.Add(new Trader(new CheaterStategy()));
                _traders.Add(new Trader(new MimicStrategy()));
                _traders.Add(new Trader(new RandomStrategy()));
                _traders.Add(new Trader(new OffensiveStrategy()));
                _traders.Add(new Trader(new FiveCounterStrategy()));
                // _traders.Add(new Trader(new StangeStrategy()));
            }

        }

        public void NextYear()
        {
            var shuffle = new List<Tuple<Trader, Trader>>();

            foreach (var a in _traders)
            foreach (var b in _traders)
                for (var i = Strategy.Random.Next(5, 10); i >= 0; --i) shuffle.Add(Tuple.Create(a, b));


            foreach (var pair in shuffle.OrderBy(_ => Strategy.Random.Next()))
            {
                pair.Item1.Deal(pair.Item2);
                pair.Item2.Deal(pair.Item1);
            }

            _traders.Sort((a, b) => b.Income.CompareTo(a.Income));

            for (var i = 0; i < _traders.Count * Settings.Default.TraderPercentToKillOff; ++i)
            {
                _traders[_traders.Count - i - 1] = _traders[i].Clone();
            }

            foreach (var a in _traders)
            {
                a.NextYear();
            }
        }
        public IEnumerator<Trader> GetEnumerator() => _traders.Cast<Trader>().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
