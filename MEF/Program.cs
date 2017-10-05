using MEF.SimpleCalculator;
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF
{   
    public class Program
    {
        private readonly CompositionContainer _container;

        [Import(typeof(ICalculator))]
        public ICalculator Calculator { get; set; }
        private Program()
        {
            var catalog = new AggregateCatalog();          
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(@"C:\Users\5005288\Documents\Visual Studio 2017\Projects\MEF\MEF\Extensions"));
            _container = new CompositionContainer(catalog);          
            try
            {
                _container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                Console.WriteLine(compositionException.ToString());
            }
        }

        public static void Main(string[] args)
        {
            var program = new Program();
            string command;            
            while (true)
            {
                Console.WriteLine("Enter Command: Ex 2+3");
                command = Console.ReadLine();
                Console.WriteLine("Result: {0}", program.Calculator.Calculate(command));
            }
        }
    }
}
