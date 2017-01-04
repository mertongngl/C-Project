using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
    class BSTNode<T> where T : IComparable
    {
        T value;
        T frequency;
        T fileNum;
        BSTNode<T> left, right;


        public BSTNode(T val,T frequency,T fileNum)
        {
            Value = val;
            this.frequency = frequency;
            this.fileNum = fileNum;
        }
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

        internal BSTNode<T> Left
        {
            get
            {
                return left;
            }

            set
            {
                left = value;
            }
        }

        internal BSTNode<T> Right
        {
            get
            {
                return right;
            }

            set
            {
                right = value;
            }
        }

        public T Frequency
        {
            get
            {
                return frequency;
            }

            set
            {
                frequency = value;
            }
        }

        public T FileNum
        {
            get
            {
                return fileNum;
            }

            set
            {
                fileNum = value;
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
