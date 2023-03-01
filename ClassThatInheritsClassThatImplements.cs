using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public class ClassThatInheritsClassThatImplements : ClassThatImplements, InterfaceThatsImplemented, SecondInterfaceThatsImplemented
    {
        public int InterfaceProperty_withAttribute_2 { get; }

        public ClassThatInheritsClassThatImplements(int int1, int int2, int int3) : base(int2, int3)
        {
            InterfaceProperty_withAttribute_2 = int1;
        }

        public override void PresentYourself(ClassThatReadsAttribute reader)
        {
            PrintingUtils.PresentClass(reader, typeof(ClassThatInheritsClassThatImplements), this);
        }

        //public void Print(ClassThatReadsAttribute reader)
        //{
        //    var typeFilter = new TypeFilter(InteraceNotInherited);
        //    var type = typeof(ClassThatInheritsClassThatImplements);
        //    Console.WriteLine("I am " + type.Name + " and these are my variables: ");
        //    reader.Print(this, type);
        //    foreach (Type interfaceType in type.FindInterfaces(typeFilter, type.BaseType))
        //    {
        //        reader.Print(this, interfaceType);
        //    }
        //    base.Print(reader);
        //    Console.WriteLine("------------------------------------");
        //    Console.WriteLine();
        //}
        public static bool InteraceNotInherited(Type typeObj, Object criteriaObj)
        {
            var baseType = (Type)criteriaObj;
            return !baseType.GetInterfaces().Contains(typeObj);
        }
    }
}
