using MEF.SimpleCalculator;
using System.ComponentModel.Composition;

namespace ExtendedOperations
{
    [Export(typeof(IBinaryOperation))]
    [ExportMetadata("Symbol",'%')]
    public class Mod : IBinaryOperation
    {
        public int Operate(int leftData, int rightData)
        {
            return leftData % rightData;
        }
    }
}
