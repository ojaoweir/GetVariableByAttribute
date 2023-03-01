using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public class ClassThatIsInherited
    {
        [VariableAttribute]
        protected int protected_parentVariable_withAttribute;
        [VariableAttribute]
        private int private_parentVariable_withAttribute;

        public ClassThatIsInherited(int intIn)
        {
            private_parentVariable_withAttribute = intIn;
        }

        public virtual void PresentYourself(ClassThatReadsAttribute reader)
        {
            PrintingUtils.PresentClass(reader, typeof(ClassThatIsInherited), this);
        }

    }
}
