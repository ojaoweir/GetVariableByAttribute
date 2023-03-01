using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVariableByAttribute
{
    /*
     * A attribute that can be se on fields (variables) and on properties
     * ex field : int number = 5;
     * ex property : int number { get; }
     * 
     * Can be used to read members (both fields and properties) and to set fields.
     */
    [System.AttributeUsage(System.AttributeTargets.All)]
    public class VariableAttribute : System.Attribute
    {

    }
}
