using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15253041VYHW1_1_
{
    class Operation<T> where T : IComparable
    {
        public Stack<T> Cikar(Stack<T> st, T n) //Search methodunda ufak değişiklikler yaptım
        {
            Stack<T> yedek = new Stack<T>(st.size());
            while (!st.isEmpty())
            {
                T deger = st.pop();
                if (deger.CompareTo(n) != 0) // Pop edilen deger n ye eşit olmadıgı surece yedek stack'e push ediyorum
                {
                    yedek.push(deger);
                }
                else if (deger.CompareTo(n) == 0)
                {
                    Console.WriteLine("Deger[ {0} ] bulundu ve cıkartıldı!", n);
                }
                else
                {
                    Console.WriteLine("Deger bulunamadı!");
                }
            }
            st.clear(); //burada işimi garantiye alıyorum :)
            while (!yedek.isEmpty())
            {
                st.push(yedek.pop());
            }
            return st;
        }
        Stack<T> birlestir(Stack<T> stc1, Stack<T> stc2) //Aldığı iki stack'i bir stackte birleştirip döndüren method
        {
            Stack<T> stc = new Stack<T>(stc1.size() + stc2.size());
            while (!stc1.isEmpty())
            {
                stc.push(stc1.pop());
            }
            while (!stc2.isEmpty())
            {
                stc.push(stc2.pop());
            }
            return stc;
        }
        public Stack<T> sirala(Stack<T> s1, Stack<T> s2)
        {
            Stack<T> anaStack = birlestir(s1, s2);
            Stack<T> yedek = new Stack<T>(anaStack.size());
            while (!anaStack.isEmpty())
            {
                T deger = anaStack.pop();
                while (!yedek.isEmpty() && yedek.peek().CompareTo(deger) == 1) //anastackten pop edilen degeri yedek stackin en ustundeki elemanla karşılaştırıyor pop edilen eleman büyükse yedek stack e push ediyor
                {                                                               //pop edilen deger yedek stackin en ustundeki elemandan kucukse anastack e push ediyor
                    anaStack.push(yedek.pop());
                }
                yedek.push(deger);
            }
            return yedek;//yedekde peek() teki eleman en buyuk olacak sekılde sıralanıyor
        }

        public void AltKumeQueue(CircularQueue<T> que1,CircularQueue<T> que2)
        {
            int i = 0;
            int j = 0;
            CircularQueue<T> queYedek2 = new CircularQueue<T>(que2.size());
            int kucukSize;
            if(que1.size() >= que2.size()) // altkume potansiyeli olan kucuk queue yu buluyorum
            {
                kucukSize=que2.size();
            }
            else
            {
                kucukSize=que1.size();
            }
            if (que1.isEmpty()) //bos kumede alt kumedir onu kontrol ediyorum
            {
                Console.WriteLine("1. Queue 2. Queue'in altkümesidir..!");
                return;
            }
            if (que2.isEmpty())
            {
                Console.WriteLine("2. Queue 1.Queue'in altkümesidir..!");
                return;
            }
            while (!que1.isEmpty()) //que1 den deQue ettiğim her elemanı que2 nin tüm elemanlarını deQue ederek karşılaştırıyorum bu sırada deQue ettiğim her elemanı yedek queue ya enQue yapıyorum
            {                       //que1 in sıradaki elemanıyla karşılaştırmak için que2 nin elamanlarını yedekten geri alıyorum
                T deger = que1.deQueue();
                while (!que2.isEmpty())
                {
                    T deger2 = que2.deQueue();
                    queYedek2.enQueue(deger2);
                    if (deger.CompareTo(deger2) == 0)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                    if (i == kucukSize - (j-1)) //bu sorgudaki amaç queue tam dolu olmayabilir ikinci sayacla bu durumu kontrol edebiliyorum
                    {
                        Console.WriteLine("Altkümesidir..!");
                        return;
                    }
                }
                while (!queYedek2.isEmpty())
                {
                    que2.enQueue(queYedek2.deQueue());
                }
            }
            Console.WriteLine("Altkümesi değildir..!");
        }
    }
}
