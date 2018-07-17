using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class OffensiveStrategy : Strategy
    {
        private bool _isLiar;

        public override Strategy Clone() => new OffensiveStrategy();

        public override bool NextTurn(Trader partner)
        {
            if (partner?.IsLiar ?? false) _isLiar = true;
            return _isLiar;
        }
    }
}
