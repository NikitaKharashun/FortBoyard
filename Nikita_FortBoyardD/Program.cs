using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary1;
using ClassLibrary2;
using Nikita_FortBoyardD.Elements;

namespace FortBoyard
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryOne.FirstLib();

            LibraryTwo.SecondLibrary();

            Console.ReadKey();
        }
    }
}