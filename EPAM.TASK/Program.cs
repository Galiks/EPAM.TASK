using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteAndReadInformation file = new WriteAndReadInformation();

            file.ChooseCommand();
        }
    }
}
        
