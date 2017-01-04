using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15253041VYHW2_1_
{
    class Run
    {
        static void Main(string[] args)
        {
            DoubleLinkList<int> Dlist = new DoubleLinkList<int>();
            DoubleLinkList<int> DList2 = new DoubleLinkList<int>();
            TxtDenCek(Dlist,DList2);
            Dlist.Display();
            Console.WriteLine();
            DList2.Display();
            Console.WriteLine();
            Dlist.Ara(Dlist, DList2);
            Console.WriteLine();
            Dlist.Ara2(Dlist, DList2);
            Console.WriteLine();
            Console.WriteLine("İkinci arama algoritması sürekli tekrar eden verileri okumada avantajlıyken\nilk arama algoritması tekrarın az olduğu\nbirbirinden farklı verileri okumada daha avantajlı ve hızlıdır");
            Console.WriteLine();
            Dlist.Sirala(Dlist);
            Dlist.Display();
        }

        static void TxtDenCek(DoubleLinkList<int> Dlist,DoubleLinkList<int> DList2)
        {
            StreamReader dosya = new StreamReader("numbers.txt");
            string _string;
            if ((_string = dosya.ReadLine()) == null)
            {
                throw new Exception("Dosya bos okunamadı..!");
            }
            else
            {
                for (int i = 0; i < _string.Split(',').Length; i++)
                {
                    Dlist.AddToEndModified(Convert.ToInt32(_string.Split(',')[i]));//AddToEndModified methodu aynı olan değerleri eklemiyor
                }
            }
            if ((_string = dosya.ReadLine()) == null)
            {
                throw new Exception("Dosya bos okunamadı..!");
            }
            else
            {
                for (int i = 0; i < _string.Split(',').Length; i++)
                {
                    DList2.AddToEnd(Convert.ToInt32(_string.Split(',')[i]));//duz sondan ekleme methodu
                }
            } 
        }
    }
}
