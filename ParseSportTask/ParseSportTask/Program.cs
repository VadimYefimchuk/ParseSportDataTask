using ParseSportTask.Classes;
using ParseSportTask.Shared;
using System;

namespace ParseSportTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var sport = new Sport();

            sport.GetSportInfo(SharedFeatures.GetSportType());

            Console.ReadKey();
        }
    }
}