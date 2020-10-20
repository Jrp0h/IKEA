using System;

namespace ikea
{
    static class Register{
        static bool[][] memory;

        public static void Initialize()
        {
            memory = new bool[32][];

            for(int i = 0; i < memory.Length; i++)
            {
               memory[i] = new bool[16]; 
               ResetMemoryAt(i);
            }
        }

        public static void SetRegister(int _addr, int _value)
        {
            bool isNegative = _value < 0;

            if(isNegative)
                _value *= -1;

           if(_addr >= memory.Length)
              throw new Exception("Invalid Memory Address!");

           ResetMemoryAt(_addr);

            for(int i = 0; _value != 0; i++)
            {
              memory[_addr][memory[_addr].Length - 1 - i] = (_value % 2) == 1; 
              _value = (int)Math.Floor((float)_value / 2.0f);
            }

            // if(isNegative)
            // two complatiance on the new memory
        }

        private static void ResetMemoryAt(int _addr)
        {
            if(_addr >= memory.Length)
                throw new Exception("Invalid Memory Address!");

            for(int i = 0; i < memory[_addr].Length; i++)
            {
                memory[_addr][i] = false;
            }
        }
    } 
}
