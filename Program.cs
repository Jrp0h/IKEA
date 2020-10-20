using System;

namespace ikea
{
    class Program
    {
        static void Main(string[] args)
        {
            IKEA.Load("test.ikea");

            // IKEA.PrintSections();
            // IKEA.PrintFunctions();

            IKEA.Run();
        }
    }
}
