using System.ComponentModel.Composition;

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
