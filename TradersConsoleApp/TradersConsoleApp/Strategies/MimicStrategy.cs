using TradersConsoleApp.Abstract;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Strategies
{
    public class MimicStrategy : Strategy
    {
        public override Strategy Clone() => new MimicStrategy();
        public override bool NextTurn(Trader partner) => partner?.IsLiar ?? false;
    }
}
