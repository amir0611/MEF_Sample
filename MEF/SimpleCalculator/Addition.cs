using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF.SimpleCalculator
{
    [Export(typeof(IBinaryOperation))]
    [ExportMetadata("Symbol",'+')]
    public class Addition : IBinaryOperation
    {
        public int Operate(int leftData, int rightData)
        {
            return leftData + rightData;
        }        
    }
}
