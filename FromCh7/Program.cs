using System;
using System.Collections.Generic;

namespace FromCh7
{
    public class MusicTitle
    {
        string[] names = { "name1", "name2", "name3", "name4" };
        public IEnumerator<string> GetEnumerator()
        {
            for(int i = 0; i < 4; i++)
            {
                yield return names[i];
            }
        }

        public IEnumerable<string> Resverse()
        {
            for(int i = 3; i >= 0; i--)
            {
                yield return names[i];
            }
        }
        public IEnumerable<string> Subset(int index, int length)
        {
            for(int i=index-1;i<4 && i < (index + length); i++)
            {
                yield return names[i];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();
            pro.MusicTitlePractice();
        }
        public void MusicTitlePractice()
        {
            MusicTitle music = new MusicTitle();
            foreach(var i in music)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Reserve");
            foreach(var i in music.Resverse())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("Subset");
            foreach(var i in music.Subset(2, 4))
            {
                Console.WriteLine(i);
            }


        }
    }
}
