using System;

namespace ikea.Token
{
    class JMPBToken : Token {
        
        public JMPBToken() : base("JMPB"){}

        protected override bool ParseLine(string[] _parts, int _lineNumber)
        {
            // TODO: Get from a callStack
            int callFromLine = IKEA.GetCallFromLine();

            if(callFromLine == -1)
                throw new Exception($"Can't return to a function that has never been called");

            IKEA.SetCallFromLine(-1);
            IKEA.SetNextLine(callFromLine);

            return true;
        }
    } 
}
