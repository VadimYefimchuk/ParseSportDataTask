using System;

namespace ParseSportTask.Shared
{
    public class SharedFeatures
    { 
        public static int GetSportType()
        {
            Console.WriteLine("What do you want to watch? \n 1 - Football \n 5 - Icehokey \n 3 - Tennis");

            return Convert.ToInt32(Console.ReadLine());
        }
    }
}