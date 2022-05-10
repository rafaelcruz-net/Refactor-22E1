﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public interface IScoreCalculator
    {
        string Calculate(Player playerA, Player playerB);
    }
}
