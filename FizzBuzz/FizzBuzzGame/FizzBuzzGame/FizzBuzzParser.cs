using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzGame
{
    public static class FizzBuzzParser
    {
        public static string Write(int data) => data switch
        {
            var p when data % 3 == 0 && data % 5 == 0 => "FizzBuzz",
            var p when data % 3 == 0 => "Fizz",
            var p when data % 5 == 0 => "Buzz",
            _ => data.ToString(),
        };
    }
}
