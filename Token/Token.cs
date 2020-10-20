using System;

namespace ikea.Token
{
    class Token {

        protected string instruction;
        public string Instruction { get { return instruction; } }
        
        public Token(string _instruction)
        {
            instruction = _instruction.ToUpper();
        }

        public bool Parse(string _line, int _lineNumber = 0)
        {
            string[] parts = _line.Split(' ');

            // Instruction
            if(parts[0].ToUpper() != instruction)
                return false;

            // TODO: Fix so that there are only 2 parts
            //
            // for(int i = 2; i < parts.Length; i++)
            // {
                // parts[1] += " " + parts[i]; 
            // }

            // System.Console.WriteLine(parts.Length);

            return ParseLine(parts, _lineNumber);
        }

        protected virtual bool ParseLine(string[] _parts, int _lineNumber = 0)
        {
            throw new NotImplementedException();
        }

        protected void CheckLength(int _length, int _expected, int _lineNumber)
        {
            if(_length != _expected)
                throw new Exception($"Invalid argument length on line {_lineNumber}, expected {_expected} but got {_length}");
        }
    } 
}
