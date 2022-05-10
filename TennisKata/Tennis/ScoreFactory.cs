﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class ScoreFactory
    {
        public static IScoreCalculator Create()
        {
            return new TennisCalculator();
        }
        
    }
}
