using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack
    {
        object[] arr;
        ushort sp;
        ushort size;

        public Stack(ushort size)
        {
            this.size = size;
            arr = new object[size];
            sp = 0;
        }
        
        public void Push(object obj)
        {
            arr[sp] = obj;
            sp++;
        }

        public object Pop()
        {
            return arr[sp-- - 1];
        }

        public object Peek(ushort n)
        {
            return arr[sp - n - 1];
        }
    }
}
