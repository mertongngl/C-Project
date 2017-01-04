using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15253041VYHW1_1_ 
{
    class Run
    {
        static void Main(string[] args)
        {
        //    Operation<int> oper = new Operation<int>();
            //Stack<int> st1 = new Stack<int>(5);
            //Stack<int> st2 = new Stack<int>(5);
            //st1.push(1);
            //st1.push(9);
            //st1.push(2);
            //st1.push(8);
            //st1.push(4);
            //oper.sirala(st1, st2).display();
            //CircularQueue<int> que1 = new CircularQueue<int>(5);
            //CircularQueue<int> que2 = new CircularQueue<int>(3);
            //que1.enQueue(3);
            //que1.enQueue(4);
            //que1.enQueue(5);
            //que1.enQueue(6);
            //que2.enQueue(4);
            //que2.enQueue(5);
            //oper.AltKumeQueue(que1,que2);
            //st2.push(11);
            //st2.push(13);
            //st2.push(15);
            //Console.WriteLine("stack 1.............");
            //st1.display();
            //Console.WriteLine("stack 2.............");
            //st2.display();
            //Console.WriteLine();
            //Stacki yedeklemediğimden cikar methodunu sıraladan sonraya aldım haberiniz olsun mumkunse puan kırmasanız
            //oper.Cikar(st1, 78); 
            //st1.display();

            Operation<string> s_oper = new Operation<string>();
            Operation<int> i_oper = new Operation<int>();
            CircularQueue<int> que1 = new CircularQueue<int>(4);
            CircularQueue<int> que2 = new CircularQueue<int>(5);
            que1.enQueue(2);
            que1.enQueue(3);
            que1.enQueue(4);
            que2.enQueue(2);
            que2.enQueue(3);
            que2.enQueue(3);
            que2.enQueue(2);
            i_oper.AltKumeQueue(que1,que2);
            //i_oper.Cikar(i_stack1, 5).display();

        }
    }
}
