using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace MEF.SimpleCalculator
{
    [Export(typeof(ICalculator))]
    public class MySimpleCalculator : ICalculator
    {
        [ImportMany]
        IEnumerable<Lazy<IBinaryOperation, IOperationData>> Operations { get; set; }

        public string Calculate(string inputCommand)
        {           
            int symbolIndex = FindSymbolIndex(inputCommand);  

            if (symbolIndex < 0)
            {
                return "Could not parse command.";
            }

            int left;
            int right;
            try
            {
                left = int.Parse(inputCommand.Substring(0, symbolIndex));
                right = int.Parse(inputCommand.Substring(symbolIndex + 1));
            }
            catch
            {
                return "Could not parse command.";
            }

            var inputSymbol = inputCommand[symbolIndex];

            var operationRequiredAsPerInputSymbol = Operations.FirstOrDefault(op => op.Metadata.Symbol.Equals(inputSymbol))?.Value;                          

            if (operationRequiredAsPerInputSymbol != null)
            {
                return operationRequiredAsPerInputSymbol.Operate(left, right).ToString();
            }

            return "Operation Not Found!";
        }

        private int FindSymbolIndex(string inputCommand)
        {
            for (int index = 0; index < inputCommand.Length; index++)
            {
                if (!(char.IsDigit(inputCommand[index])))
                {
                    return index;
                }
            }

            return -1;
        }        
    }
}
