using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bst
{
    class Operations<T> where T:IComparable
    {
        string[] fileNumber = new string[5954];
        string[] word = new string[5954];
        string[] frequency = new string[5954];
        BinarySearchTree<string> BST = new BinarySearchTree<string>();
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
            AddToBST(5954);
        }
        public void AddToBST(int length)
        {
            for (int i = 0; i < length; i++)
            {
                BST.Add(word[i], frequency[i], fileNumber[i]);
            }
            BST.InOrder();
        }
    }
}
