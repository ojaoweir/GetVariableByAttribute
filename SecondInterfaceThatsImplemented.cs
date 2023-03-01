using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{

    public interface SecondInterfaceThatsImplemented
    {
        [VariableAttribute]
        public int InterfaceProperty_withAttribute_2 { get; }
    }
}
