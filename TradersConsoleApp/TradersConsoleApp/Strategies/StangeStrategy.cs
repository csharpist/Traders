using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class StangeStrategy : Strategy
    {
        private int _lostTimes = 1;

        public override Strategy Clone() => new StangeStrategy();

        public override bool NextTurn(Trader partner)
        {
            if (partner?.IsLiar ?? false) _lostTimes += 4;
            return --_lostTimes > 0;
        }
    }
}
