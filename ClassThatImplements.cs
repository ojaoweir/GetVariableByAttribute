using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public class ClassThatImplements : InterfaceThatsImplemented
    {
        public int InterfaceProperty_withAttribute { get; private set; }

        [VariableAttribute]
        private int private_variable_withAttribute;
        public ClassThatImplements(int int1, int int2)
        {
            InterfaceProperty_withAttribute = int1;
            private_variable_withAttribute = int2;
        }
        public virtual void PresentYourself(ClassThatReadsAttribute reader)
        {
            PrintingUtils.PresentClass(reader, typeof(ClassThatImplements), this);

            //var type = typeof(ClassThatImplements);
            //Console.WriteLine("I am " + type.Name + " and these are my variables: ");
            //reader.Print(this, type);
            //foreach (Type interfaceType in type.GetInterfaces())
            //{
            //    reader.Print(this, interfaceType);
            //}
            //Console.WriteLine("------------------------------------");
            //Console.WriteLine();
        }
    }

}
