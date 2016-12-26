using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stack
{
    class Operations<T> where T : IComparable
    {
        string[] fileNumber = new string[5954];
        string[] word = new string[5954];
        string[] frequency = new string[5954];
        Stack<string> fileNumStack = new Stack<string>(5954);
        Stack<string> wordStack = new Stack<string>(5954);
        Stack<string> frequencyStack = new Stack<string>(5954);
        StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\merto\Desktop\C# Project\vya2016veriler.csv"));//dosya yolunu duzelt!!
        public void takeIt()
        {
            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                fileNumber[i] = values[0].ToString().Trim('"').Trim();
                word[i] = values[1].ToString().Trim('"').Trim();
                frequency[i] = values[2].ToString().Trim('"').Trim();
                i++;
            }
            PushStack(5954);
        }
        private void PushStack(int length)
        {
            for (int i = 0; i < length; i++)
            {
                fileNumStack.push(fileNumber[i]);
                wordStack.push(word[i]);
                frequencyStack.push(frequency[i]);
            }
            SortAndWrite(wordStack,fileNumStack,frequencyStack);
        }
        private void SortAndWrite(Stack<string> stWord,Stack<string> stFileNum,Stack<string> stFrequency)
        {
            int counter = 0;
            Stack<string> helperStackWord = new Stack<string>(stWord.size());
            Stack<string> helperStackFileNum = new Stack<string>(stWord.size());
            Stack<string> helperStackFrequency = new Stack<string>(stWord.size());
            string current;
            string current2;
            string current3;
            while (!stWord.isEmpty())
            {
                counter++;
                current = stWord.pop(); //siralanacak stackten current a pop ediyoruz degeri
                current2 = stFileNum.pop();
                current3 = stFrequency.pop();
                while (!helperStackWord.isEmpty() && current.CompareTo(helperStackWord.peek()) == -1) //yardımcı stackin peek() indeki eleman currenttan buyukse 
                {                                                                                     //helperstacklerden anastacklere atılıyor degerler
                    counter++;
                    stWord.push(helperStackWord.pop());
                    stFileNum.push(helperStackFileNum.pop());
                    stFrequency.push(helperStackFrequency.pop());
                }
                helperStackWord.push(current);
                helperStackFileNum.push(current2);
                helperStackFrequency.push(current3);
            }
            stWord.clear(); //bide bu yuzden hata almayayım diye yapılmıs bır sey ama gereksiz buyuk ıhtımalle
            stFileNum.clear();
            stFrequency.clear();
            while (!helperStackWord.isEmpty()) //burda anastacklere aktarma
            {
                counter++;
                stWord.push(helperStackWord.pop());
                stFileNum.push(helperStackFileNum.pop());
                stFrequency.push(helperStackFrequency.pop());
            }
            StringBuilder csvcontent = new StringBuilder();
            while (!stWord.isEmpty())
            {
                csvcontent.AppendLine(stFileNum.pop() + ',' + '"' + stWord.pop() + '"' + ',' + stFrequency.pop());
            }
            File.AppendAllText(@"C:\Users\merto\Desktop\C# Project\cikti\sonuc.stack.XYZT.csv", csvcontent.ToString()); //burdaki dosya yolunu da duzelt
            Console.WriteLine("Dosya Kaydedilmistir..! Sayac:{0}",counter.ToString());
        }
    }
}
