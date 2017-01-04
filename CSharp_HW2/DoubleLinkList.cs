using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15253041VYHW2_1_
{
    class DoubleLinkList<T> where T:IComparable
    {
        DNode<T> head;

        public void AddToFront(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            if (head == null)
                head = newNode;
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }

        public void AddToEnd(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            DNode<T> iterator = head;
            if (head == null)
                head = newNode;
            else
            {
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Next = newNode;
                newNode.Prev = iterator;
            }
        }

        public void AddToEndModified(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            DNode<T> iterator = head;
            if (head == null)
                head = newNode;
            else
            {
                if (!Search(val)) //search methodundan false dondugu surece ekliyor
	            {
                    while (iterator.Next != null)
                    {
                        iterator = iterator.Next;
                    }
                    iterator.Next = newNode;
                    newNode.Prev = iterator;
	            }
            }
        }

        public void DeleteLast()
        {
            DNode<T> iterator = head;

            if (head == null || head.Next == null)
                head = null;
            else
            {
                while (iterator.Next != null)
                {
                    iterator = iterator.Next;
                }
                iterator.Prev.Next = null;
            }
        }

        public void Display()
        {
            DNode<T> iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.Value + " ");
                iterator = iterator.Next;
            }
            Console.WriteLine();
        }

        public void DisplayReverse()
        {
            DNode<T> iterator = head;
            if (head == null)
                return;
            while (iterator.Next != null)
            {
                iterator = iterator.Next;
            }
            while (iterator != null)
            {
                Console.Write(iterator.Value+" ");
                iterator = iterator.Prev;
            }
            Console.WriteLine();
        }

        public bool Search(T val)
        {
            DNode<T> iterator = head;
            bool flag=false;
            if (head == null)
                Console.WriteLine("The linked list is empty!!!");
            else
            {
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) == 0)
                    {
                        flag = true;
                    }
                    iterator = iterator.Next;
                }
                //if (flag != 0)
                //    Console.WriteLine("The linked list includes {0}", val);
                //else
                //    Console.WriteLine("The linked list doesn't include {0}", val);
            }
            return flag;
        }

        public void Delete(T val)
        {
            DNode<T> iterator = head;
            if (head == null)
                return;
            else
            {
                while (iterator != null)
                {
                    if (iterator.Value.CompareTo(val) == 0)
                    {
                        if (iterator.Prev == null && iterator.Next==null)
                        {
                            head = null;
                        }
                        else if(iterator.Prev == null)
                        {
                            head = iterator.Next;
                            head.Prev = null;
                        }
                        else if(iterator.Next == null)
                        {
                            iterator.Prev.Next = null;
                        }
                        else
                        {
                            iterator.Next.Prev = iterator.Prev;
                            iterator.Prev.Next = iterator.Next;
                        }
                        Delete(val);
                        break;
                    }
                    else
                        iterator = iterator.Next;
                } 
            }
        }

        public void AddToOrderedList(T val)
        {
            DNode<T> newNode = new DNode<T>(val);
            DNode<T> iterator = head;
            if (head == null)
                head = newNode;
            else
            {
                if (head.Value.CompareTo(val) > 0)
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
                else
                {
                    while (iterator.Next != null && iterator.Next.Value.CompareTo(val) <= 0)
                    {
                        iterator = iterator.Next;
                    }

                    newNode.Next = iterator.Next;
                    if(iterator.Next!=null)
                        iterator.Next.Prev = newNode;
                    newNode.Prev = iterator;
                    iterator.Next = newNode;
                }
            }
        }

        public void Ara(DoubleLinkList<T> DList,DoubleLinkList<T> DList2)
        {
            DNode<T> iteratorMain=DList.head;
            DNode<T> iteratorSearch=DList2.head;
            float avg = 0;
            int counter = 0;
            int sum = 0;
            while (iteratorSearch != null)
	        {
                counter++;
                while (iteratorMain != null)
	            {
                    sum++;
                    if(iteratorSearch.Value.CompareTo(iteratorMain.Value) == 0) //deger bulundugunda break ediyorum
                    {
                        break;
                    }
                    iteratorMain = iteratorMain.Next;
	            }
                iteratorMain=DList.head;
	            iteratorSearch = iteratorSearch.Next;
	        }
            avg = (float)sum / (float)counter; //toplam erişim sayısını aranacak deger sayısına boluyorum
            Console.WriteLine("Toplam Erişim Sayısı: {0}\nAranacak Değer Sayısı: {1}\nOrtalama Erişim Sayısı: {2}",sum,counter,avg);

        }

        public void Ara2(DoubleLinkList<T> DList, DoubleLinkList<T> DList2)
        {
            DNode<T> iteratorMain = DList.head;
            DNode<T> iteratorSearch = DList2.head;
            float avg = 0;
            int counter = 0;
            int sum = 0;
            while (iteratorSearch != null)
            {
                counter++;
                while (iteratorMain != null)
                {
                    sum++;
                    if (iteratorSearch.Value.Equals(iteratorMain.Value)) //degeri buldugunda degeri siliyorum(tekrar eden degerler olmadıgı ıcın sıkıntı yok) ve basa ekliyorum
                    {
                        DList.Delete(iteratorSearch.Value);
                        DList.AddToFront(iteratorSearch.Value);
                        break;
                    }
                    iteratorMain = iteratorMain.Next;
                }
                iteratorMain = DList.head;
                iteratorSearch = iteratorSearch.Next;
            }
            avg = (float)sum / (float)counter; //toplam erişim sayısını aranacak deger sayısına boluyorum
            Console.WriteLine("Toplam Erişim Sayısı: {0}\nAranacak Değer Sayısı: {1}\nOrtalama Erişim Sayısı: {2}", sum, counter, avg);
        }

        public void Sirala(DoubleLinkList<T> DList)
        {
            DNode<T> min = DList.head, iterator = DList.head, temp = DList.head;
            T val;
            while (min != null)
            {
                val = min.Value;//minin o anki degerini val ya atıyorum
                iterator = min;//sıralanan elemanları atlıyor bu sekilde esitleyince
                temp = min;
                while (iterator.Next != null)
                {
                    if (val.CompareTo(iterator.Next.Value) == 1) //minin o anki degeri bir sonraki elemandan buyuk oldugu surece val ya iterator.Next value sunu atıyor temp e iteratorun next inin atıyor
                    {
                        val = iterator.Next.Value;
                        temp = iterator.Next;
                    }
                    iterator = iterator.Next;
                }
                temp.Value = min.Value;//node ların yerlerini degistirmektense value larını degistiriyorum
                min.Value = val;
                min = min.Next;
            }
        }
    }
    }
