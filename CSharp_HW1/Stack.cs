using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15253041VYHW1_1_
{
    class Stack<T> where T : IComparable
    {
        int top;
        T[] values;
        public Stack(int size)
        {
            values = new T[size];
            top = -1;
        }
        public void clear()
        {
            top = -1;
        }
        public int size()
        {
            return values.Length;
        }
        public T peek()
        {
            if (top == -1)
            {
                return default(T);
            }
            else
            {
                return values[top];
            }
        }
        public bool isEmpty()
        {
            if (top == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isFull()
        {
            if (top == values.Length - 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void push(T value)
        {
            if (isFull())
            {
                Console.WriteLine("stack is full");
            }
            else
            {
                top++;
                values[top] = value;
            }
        }
        public T pop()
        {
            if (isEmpty())
            {
                Console.WriteLine("stack is empty");
                return default(T);
            }
            else
            {
                top--;
                return values[top + 1];
            }
        }
        public void display()
        {
            for (int i = top; i > -1; i--)
            {
                Console.WriteLine(values[i]);
            }
        }
    }
}

