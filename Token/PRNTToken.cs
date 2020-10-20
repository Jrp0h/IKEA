using System;

namespace ikea.Token
{
    class PRNTToken : Token {
        
        public PRNTToken() : base("PRNT"){}

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // Only instruction and name
            if(_parts.Length != 2)
                System.Console.WriteLine("Hello from prnt");
            else
                System.Console.WriteLine(_parts[1]);


            return true;
        }
    } 
}
