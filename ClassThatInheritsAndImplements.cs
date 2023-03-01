using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public class ClassThatInheritsAndImplements : ClassThatIsInherited, InterfaceThatsImplemented
    {
        [VariableAttribute]
        private int private_variable_withAttribute;
        public int InterfaceProperty_withAttribute { get; }
        public ClassThatInheritsAndImplements(int int1, int int2, int int3, int int4) : base(int4)
        {
            private_variable_withAttribute = int1;
            protected_parentVariable_withAttribute = int2;
            InterfaceProperty_withAttribute = int3;
        }

        public override void PresentYourself(ClassThatReadsAttribute reader)
        {
            PrintingUtils.PresentClass(reader, typeof(ClassThatInheritsAndImplements), this);
        }

        //public override void Print(ClassThatReadsAttribute reader)
        //{
        //    Console.WriteLine("I am " + this.GetType().Name + " and these are my variables: ");
        //    reader.Print(this, GetType());
        //    foreach (Type interfaceType in GetType().GetInterfaces())
        //    {
        //        reader.Print(this, interfaceType);
        //    }
        //    if (GetType().BaseType != typeof(object) && GetType().BaseType != null)
        //    {
        //        base.Print(reader);
        //    }
        //    Console.WriteLine("------------------------------------");
        //    Console.WriteLine();
        //}
    }
}
