using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public class ClassThatInherits : ClassThatIsInherited
    {
        [VariableAttribute]
        private int private_childVariable_withAttribute;
        public ClassThatInherits(int int1, int int2) : base(int2)
        {
            private_childVariable_withAttribute = int1 - int2;
            protected_parentVariable_withAttribute = int1;
        }
        public override void PresentYourself(ClassThatReadsAttribute reader)
        {
            PrintingUtils.PresentClass(reader, typeof(ClassThatInherits), this);
        }
    }
}
