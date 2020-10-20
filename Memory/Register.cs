using System;
using System.Collections.Generic;

namespace ikea.Memory
{
    static class Register{
        static Memory[] memory;
        static Dictionary<string, Memory> vars;

        public static void Initialize()
        {
            memory = new Memory[32];
            vars = new Dictionary<string, Memory>(); 
        }

        public static void SetMemoryAt(int _addr, int _value)
        {
           if(_addr >= memory.Length)
              throw new Exception("Invalid Memory Address!");

           if(memory[_addr] == null)
               memory[_addr] = new Memory();

            memory[_addr].SetValue(_value);
        }

        public static void SetMemoryAt(int _addr, bool[] _value)
        {
           if(_addr >= memory.Length)
              throw new Exception("Invalid Memory Address!");

           if(memory[_addr] == null)
               memory[_addr] = new Memory();

            memory[_addr].SetValue(_value);
        }

        public static Memory GetMemoryFrom(int _addr)
        {
           if(_addr >= memory.Length)
              throw new Exception("Invalid Memory Address!");

           if(memory[_addr] == null)
               memory[_addr] = new Memory();

           return memory[_addr];
        }

        public static void PrintVars()
        {
            foreach(var v in vars)
            {
                Console.WriteLine($"{v.Key}: {v.Value.GetValue()}");
            }
        }

          public static Memory GetVar(string _name)
          {
             if(!vars.ContainsKey(_name))
                throw new Exception($"Unknown variable: {_name}");

             return vars[_name];
          }

          public static void SetVar(string _name, int _value)
          {
              vars[_name] = new Memory();
                vars[_name].SetValue(_value);
          }
    } 
}
