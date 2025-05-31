using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class Class1
    {
        public static async Task<string> Message()
        {
            await Task.Delay(1000);
            return "Narendhra";
        }
    }
}
