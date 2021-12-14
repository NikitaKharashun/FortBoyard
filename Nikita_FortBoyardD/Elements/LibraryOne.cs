using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Reflection;
using ClassLibrary1;

namespace Nikita_FortBoyardD.Elements
{
    class LibraryOne
    {
        public static void FirstLib()
        {
            var firsLib = Assembly.Load("ClassLibrary1");

            Type[] types = firsLib.GetTypes();

            foreach (var item in types)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 32));

            var start = Activator.CreateInstance(firsLib.GetType("ClassLibrary1.Begin"), null) as Begin;


            foreach (var item in start.GetType().GetNestedTypes())           
                Console.WriteLine(item.Name);
            

            Console.WriteLine(new string('-', 32));

            try
            {
                start.StartMethod();
            }
            catch (Exception e)
            {
                (Activator.CreateInstance(start.GetType().GetNestedType("Something"), null) as Begin.Something).SelectMe();

                Console.WriteLine(e.Message);
            }


            var secondClass = Activator.CreateInstance(firsLib.GetType("ClassLibrary1.SecondClass"), null) as SecondClass;


            Console.WriteLine(new string('-', 32));


            foreach (var item in secondClass.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))      
                Console.WriteLine(item.GetValue(secondClass));
            

            var message = Activator.CreateInstance(firsLib.GetType("ClassLibrary1.Message"), null) as Message;

            message.Run();

            var generatorOfKeys = Activator.CreateInstance(firsLib.GetType("ClassLibrary1.GeneratorOfKeys"), null) as GeneratorOfKeys;

            Console.WriteLine(new string('-', 32));

            generatorOfKeys.generator();

            Console.WriteLine(new string('-', 32));
           
            int key = 19610412;

            Cipher(Info(), key);

            Console.WriteLine(new string('-', 32));
            Console.WriteLine(new string('-', 32));
        }

        private static void Cipher(string text, int secretKey)
        {
            var result = string.Empty;
            foreach (var item in text)        
                result += Convert.ToString((object)(char)(item ^ secretKey));
            
            Console.WriteLine(result);
        }

        private static string Info()
        {
            string code = string.Empty;

            using (var readStream = new StreamReader(@"./task.txt"))
            {
                return code = readStream.ReadToEnd();
            }               
        }
    }
}
