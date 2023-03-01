using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public static class PrintingUtils
    {
        public static void PresentClass<T>(ClassThatReadsAttribute reader, Type type, T obj)
        {
            Console.WriteLine("I am " + type.Name + " and these are my variables: ");
            Print(reader, type, "", obj);
            Console.WriteLine("------------------------------------");
            Console.WriteLine();
        }

        private static void Print<T>(ClassThatReadsAttribute reader, Type type, string indentation, T obj)
        {
            //Print my variables
            reader.Print(obj, type, indentation);

            if (type.BaseType != null && type.BaseType != typeof(object))
            {
                Print(reader, type.BaseType, indentation + "  ", obj);
            }
        }
    }
}
