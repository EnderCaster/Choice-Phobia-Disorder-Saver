using System;

namespace Choice_Phobia_Disorder_Saver.com.endercaster.utils
{
    class Erandom
    {
        static Random rand = new Random();
        public static int getRandomPos()
        {
            return rand.Next();
        }
        public static int getRandomPos(int max)
        {
            return rand.Next(max);
        }
        
    }
}
