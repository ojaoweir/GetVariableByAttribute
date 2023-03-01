using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public class ClassWithAttribute
    {
        [VariableAttribute]
        private int private_variable_withAttribute;
        [VariableAttribute]
        protected int protected_variable_withAttribute;
        [VariableAttribute]
        public int public_variable_withAttribute;
        [VariableAttribute]
        public int public_property_withAttribute => private_variable_withAttribute + protected_variable_withAttribute + public_variable_withAttribute;
        [VariableAttribute]
        public int readonly_variable_withAttribute;

        private int private_variable_withOutAttribute;

        public ClassWithAttribute(int int1, int int2, int int3, int int4, int int5)
        {
            private_variable_withAttribute = int1;
            protected_variable_withAttribute = int2;
            public_variable_withAttribute = int3;
            readonly_variable_withAttribute = int4;
            private_variable_withOutAttribute = int5;
        }

        public void PresentYourself(ClassThatReadsAttribute reader)
        {
            PrintingUtils.PresentClass(reader, typeof(ClassWithAttribute), this);
        }

        //public void Print(ClassThatReadsAttribute reader)
        //{
        //    Console.WriteLine("I am " + this.GetType().Name + " and these are my variables: ");
        //    reader.Print(this, GetType());
        //    Console.WriteLine("------------------------------------");
        //    Console.WriteLine();
        //}
    }
}
