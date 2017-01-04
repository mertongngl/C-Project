using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace queue
{
    class Operations
    {
        string[] fileNumber = new string[5954];
        string[] word = new string[5954];
        string[] frequency = new string[5954];
        Queue<string> queueFileNum = new Queue<string>(5954);
        Queue<string> queueWord = new Queue<string>(5954);
        Queue<string> queueFrequency = new Queue<string>(5954);
        StreamReader reader = new StreamReader(File.OpenRead(@"C:\Users\merto\Desktop\C# Project\vya2016veriler.csv"));
        public void takeIt()
        {
            int i = 0;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                fileNumber[i] = values[0].ToString().Trim('"').Trim();//ikinci trim darı çıktı dan once bosluk var onu en basa aliyor
                word[i] = values[1].ToString().Trim('"').Trim();
                frequency[i] = values[2].ToString().Trim('"').Trim();
                i++;
            }
            EnqueueQueue(5954);
        }
        public void EnqueueQueue(int length)
        {
            for (int i = 0; i < length; i++)
            {
                queueFileNum.enQueue(fileNumber[i]);
                queueWord.enQueue(word[i]);
                queueFrequency.enQueue(frequency[i]);
            }
            SortAndWrite();
        }
        public void SortAndWrite()
        {
            int counter = 0;
            Queue<string> helperFileNum = new Queue<string>(queueFileNum.size());
            Queue<string> helperWord = new Queue<string>(queueWord.size());
            Queue<string> helperFrequency = new Queue<string>(queueFrequency.size());
            string x, y, temp;
            string x1, y1, temp1;
            string x2, y2, temp2;
            for (int i = 0; i < queueWord.size() - 1; i++)
            {
                counter++;
                x = queueWord.deQueue(); //x i dongunun dısında alıyorum
                x1 = queueFileNum.deQueue();
                x2 = queueFrequency.deQueue();
                while (!queueWord.isEmpty())
                {
                    counter++;
                    y = queueWord.deQueue(); //burda y yi alıyorum
                    y1 = queueFileNum.deQueue();
                    y2 = queueFrequency.deQueue();
                    if (x.CompareTo(y) < 1) //x <= y ise y ile x i swap ediyorum sebebi x de buyuk  sayıyı tutmak
                    {                        
                        temp = y;
                        temp1 = y1;
                        temp2 = y2;
                        y = x;
                        y1 = x1;
                        y2 = x2;
                        x = temp;
                        x1 = temp1;
                        x2 = temp2;
                    }
                    helperWord.enQueue(y);
                    helperFileNum.enQueue(y1);
                    helperFrequency.enQueue(y2);
                }
                helperWord.enQueue(x);
                helperFileNum.enQueue(x1);
                helperFrequency.enQueue(x2);
                queueWord.Clear();
                queueFileNum.Clear();
                queueFrequency.Clear();
                while (!helperWord.isEmpty())
                {
                    counter++;
                    queueWord.enQueue(helperWord.deQueue());
                    queueFileNum.enQueue(helperFileNum.deQueue());
                    queueFrequency.enQueue(helperFrequency.deQueue());
                }
                helperWord.Clear();
                helperFileNum.Clear();
                helperFrequency.Clear();
            }
            StringBuilder csvcontent = new StringBuilder();
            while (!queueWord.isEmpty())
            {
                csvcontent.AppendLine(queueFileNum.deQueue() + ',' + '"' + queueWord.deQueue() + '"' + ',' + queueFrequency.deQueue());
            }
            File.AppendAllText(@"C:\Users\merto\Desktop\C# Project\cikti\sonuc.queue.XYZT.csv", csvcontent.ToString());
            Console.WriteLine("Dosya Kaydedildi..! Sayac:{0}",counter.ToString());
        }
    }
}
