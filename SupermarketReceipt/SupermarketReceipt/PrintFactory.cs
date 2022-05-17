using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketReceipt
{
    public static class PrinterFactory
    {
        public static IPrinter Create(PrinterType printerType)
        {
            return printerType switch
            {
                PrinterType.Console => new ReceiptPrinter(),
                PrinterType.HTML => new ReceiptPrinterHTML(),
                _ => throw new NotImplementedException(),
            };
        }
    }

    public enum PrinterType
    {
        Console = 1,
        HTML = 2
    }
}
