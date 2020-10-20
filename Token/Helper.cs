using System;

using ikea.Memory;

namespace ikea.Token
{
    enum ValueType {Plain, Var, VarValue, Direct};

    static class Helper
    {
       public static ValueType ParseValueType(string _arg, out int _value)
       {
           _arg = _arg.Trim();
           // Used for dynamic location
           if(_arg.StartsWith("$"))
           {
              _arg = _arg.Remove(0, 1);
              _value = Register.GetMemoryFrom(Register.GetVar(_arg).GetValue()).GetValue();
              return ValueType.VarValue;
           }
           // Used for static location stored in a var
           else if(_arg.StartsWith("&"))
           {
               _arg = _arg.Remove(0, 1);
               _value = Register.GetVar(_arg).GetValue();
               return ValueType.Var;
           }
           else if(_arg.StartsWith("#"))
           {
               _arg = _arg.Remove(0, 1);

                if(!int.TryParse(_arg, out _value))
                    throw new Exception($"{_arg} is not a valid memory address");

                _value = Register.GetMemoryFrom(_value).GetValue();

               return ValueType.Direct;
           }
           // Used for static location
           else {

               // TODO: Implement hex(0x) and binary(0b)
                if(!int.TryParse(_arg, out _value))
                    throw new Exception($"{_arg} is not a valid memory address");

                return ValueType.Plain;
           }
       }
    } 
}
