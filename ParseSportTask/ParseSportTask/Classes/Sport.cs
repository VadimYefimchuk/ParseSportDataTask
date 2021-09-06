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
                Console.WriteLine("Status Code: {0}\nPlease try again!", response.StatusCode);
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
                        Console.WriteLine("\tTitle: " + leagueInfo.match.title);

                        if(leagueInfo.outcomes.Count > 0)
                        {
                            Console.WriteLine("\tOutcames: \n\t\tP1: {0}, X: {1}, P2: {2}", leagueInfo.outcomes[0].title,
                                                                                          leagueInfo.outcomes[1].title,
                                                                                          leagueInfo.outcomes[2].title);
                        }
                        
                        Console.WriteLine("\tScore: " + leagueInfo.match.score);
                        Console.WriteLine("\tMatch time: " + leagueInfo.match.match_time + "\n");
                    }
                }
            }
        }
    }
}
