﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt
{
    public interface IPrinter
    {
        string PrintReceipt(Receipt receipt);
    }
}
