using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RawDiskLib;

namespace TestApplication.Examples
{
    public class ExampleBitlocker : ExampleBase
    {
        public override string Name
        {
            get { return "Bitlocker Status Test"; }
        }

        public override void Execute()
        {
            try
            {
                Utilities.WmiHelpers.GetBitlockerStatus();
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + exception.Message);
            }
            Console.ForegroundColor = ExampleUtilities.DefaultColor;
            Console.WriteLine();
        }
    }
}
