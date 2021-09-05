using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ParseSportTask.Classes
{
    public class Sport
    {
        static readonly HttpClient client = new HttpClient();

        public async void GetSportInfo (int sportType = 1)
        {
            HttpResponseMessage response = await client.GetAsync("https://mostbet.ru/line/list?is_spa=1&t[]=2&lc[]=" + sportType + "& ss=all&l=10000/");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var sport = JsonConvert.DeserializeObject<SportEntity>(responseBody);

                ConsoleWriteSport(sport);
            }
            else
            {
                Console.WriteLine("Status Code: {0}", response.StatusCode);
            }
        }

        public void ConsoleWriteSport(SportEntity sport)
        {
            Console.Clear();

            Console.WriteLine(sport.lines_hierarchy[0].line_category_dto_collection[0].title);

            foreach (var league in sport.lines_hierarchy[0].line_category_dto_collection[0].line_supercategory_dto_collection)
            {
                Console.WriteLine(league.title);

                foreach (var leagueCollection in league.line_subcategory_dto_collection)
                {
                    Console.WriteLine(leagueCollection.title);

                    foreach (var leagueInfo in leagueCollection.line_dto_collection)
                    {
                        Console.WriteLine("\t" + leagueInfo.match.title);
                        Console.WriteLine("\t" + leagueInfo.match.score);
                        Console.WriteLine("\t" + leagueInfo.match.match_time + "\n");
                    }
                }
            }
        }
    }
}
