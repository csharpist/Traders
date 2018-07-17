﻿using System;
using TradersConsoleApp.Infrastructure;

namespace TradersConsoleApp.Abstract
{
    public abstract class Strategy
    {
        public static Random Random { get; } = new Random();
        public abstract bool NextTurn(Trader partner);
        public abstract Strategy Clone();
    }
}
