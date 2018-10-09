using System;
using System.Collections.Generic;

namespace Stack
{
    class Program
    {
        static Stack stack;

        static void Main(string[] args)
        {
            stack = new Stack(10);
            stack.Push((Action)(Add));
            stack.Push(3);
            stack.Push(5);
            DoOperation();
            //Console.WriteLine(stack.Pop());

            unsafe
            {
                fixed (char* ptr = "Hello World!\0".ToCharArray())
                {
                    PrintString(ptr);
                }
            }
            Console.WriteLine();
            unsafe
            {
                fixed (int* begin = new int[] { 5, 3, 1 })
                {
                    //Loop(begin, 3);
                }
            }

            Console.ReadKey();
        }

        static unsafe void PrintString(char* arr)
        {
            for (int i = 0; arr[i] != '\0';)
            {
                i++;
                Console.Write(arr[i] == '\0');
            }
            for (int i = 0; arr[i] != '\0'; i++)
            {
                Console.Write(arr[i]);
            }
        }

        static unsafe void Loop(int* begin, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(begin[i]);
            }
        }

        static void DoOperation()
        {
            ((Action)(stack.Peek(2))).Invoke();
        }

        static void Add()
        {
            ushort b = (ushort)stack.Pop();
            ushort a = (ushort)stack.Pop();
            stack.Pop();
            stack.Push(a + b);
        }

        static void Subtract()
        {
            Negate();
            ushort a = (ushort)stack.Pop();
            ushort b = (ushort)stack.Pop();

            stack.Push((ushort)(a + b));
        }

        static void Multiply()
        {
            stack.Push(1);
            Subtract();
            ushort result = (ushort)stack.Pop();
            if (result == 0) return;
            ushort a = (ushort)stack.Peek(0);
            stack.Push(a);
            stack.Push(result);
            Multiply();
            Add();
        }

        static void Divide()
        {
            
        }

        static ushort Multiply(ushort a, ushort b, ushort result, ushort counter) => counter >= b ? result : (Multiply(a, b, (ushort)(result + a), (ushort)(counter + 1)));

        static void Flip() => stack.Push((ushort)(~(ushort)stack.Pop()));

        static void Negate() => stack.Push((ushort)(~(ushort)stack.Pop() + 1));
    }
}
