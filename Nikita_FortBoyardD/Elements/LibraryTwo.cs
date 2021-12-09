using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary2;

namespace Nikita_FortBoyardD.Elements
{
    class LibraryTwo
    {
        public static void SecondLibrary()
        {
            var secondLib = Assembly.Load("ClassLibrary2");

            foreach (var item in secondLib.GetTypes())       
                Console.WriteLine(item);
            

            var targetClass = Activator.CreateInstance(secondLib.GetType("ClassLibrary2.TargetClass"), null) as TargetClass;
            targetClass.Metod("Пуск");

            var classWithCollection = Activator.CreateInstance(secondLib.GetType("ClassLibrary2.ClassWithCollection"), null) as ClassWithCollection;

            classWithCollection.GenCollectOfCities(@"TCP\IP");

            foreach (var item in classWithCollection.GenCollectOfCities(@"TCP\IP"))        
                Console.WriteLine(item);
          

            var list = classWithCollection.GenCollectOfCities(@"TCP\IP").ToArray().OrderBy(x => (x as dynamic).Name);

            var dict = new Dictionary<string, object>();

            foreach (City item in list)
            {
                dict.Add(item.Name, item);
                Console.WriteLine(item);
            }

            classWithCollection.NextMetod(dict);
        }
    }
}
