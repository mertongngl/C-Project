using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15253041VYHW2_1_
{
    class DNode<T> where T:IComparable
    {
        T value;
        DNode<T> next;
        DNode<T> prev;

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public DNode<T> Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }

        public DNode<T> Prev
        {
            get
            {
                return prev;
            }

            set
            {
                prev = value;
            }
        }

        public DNode(T val)
        {
            value = val;
            next = null;
        }
    }
}
