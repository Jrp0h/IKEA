using System;

namespace ikea.Memory
{
    class Memory {
        bool[] data;

        public Memory() {
            data = new bool[16];

            ResetValue();
        }

        public void SetValue(int _value)
        {
            bool isNegative = _value < 0;

            if(isNegative)
                _value *= -1;

           ResetValue();

            for(int i = 0; _value != 0; i++)
            {
             data[data.Length - 1 - i] = (_value % 2) == 1; 
              _value = (int)Math.Floor((float)_value / 2.0f);
            }

            // if(isNegative)
            // two complatiance on the new memory
        }

        public void SetValue(bool[] _value)
        {
           data = _value;
        }

        public int GetValue()
        {

            int sum = 0;
            
            for(int i = 0; i < data.Length; i++)
            {
                sum += (int)Math.Pow(2, i) * Convert.ToInt32(data[data.Length - 1 - i]);
            }

            return sum;
        }

        private void ResetValue()
        {
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = false;
            }
        }
    }
}
