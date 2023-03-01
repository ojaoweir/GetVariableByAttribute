using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    public interface InterfaceThatsImplemented
    {
        [VariableAttribute]
        public int InterfaceProperty_withAttribute { get; }
    }

}
