using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Aoc
    {
        HttpClient _client;
        Assembly _assembly = Assembly.GetExecutingAssembly();
        public Aoc(string session)
        {
            var baseUri = new Uri("https://adventofcode.com");
            var c = new CookieContainer();
            c.Add(baseUri, new Cookie("session", session));
            _client = new HttpClient(new HttpClientHandler() { CookieContainer = c }) { BaseAddress = baseUri };
        }

        public async Task<string> GetInput(DateTime date, CancellationToken cancellationToken = default)
        {
            ValidateDay(date);
            var pathFile = $"cache/{date.Year}{date.Day,00}.txt";
            if (!File.Exists(pathFile))
            {
                if (!Directory.Exists($"cache"))
                {
                    Console.WriteLine("Creating cache folder.");
                    Directory.CreateDirectory($"cache");
                }
                Console.WriteLine($"Downloading puzzle for {date.Year}{date.Day,00}");
                var result = await _client.GetStringAsync($"/{date.Year}/day/{date.Day}/input").ConfigureAwait(false);
                await File.WriteAllTextAsync(pathFile, result).ConfigureAwait(false);
                return result;
            }
            else
                Console.WriteLine($"Load file from cache.");
            {
                return await File.ReadAllTextAsync(pathFile, cancellationToken).ConfigureAwait(false); ;
            }
        }

        public async Task SolvePuzzle(DateTime date)
        {
            ValidateDay(date);
            var type = _assembly.GetType($"AdventOfCode.Y{date.Year}.D{date.Day:00}");
            if (type is null)
            {
                Console.WriteLine($"Not found");
                return;
            }
            var input = await GetInput(date);
            var obj = Activator.CreateInstance(type, input) as BaseDay;
            Console.WriteLine(obj.Part1());
            Console.WriteLine();
            Console.WriteLine(obj.Part2());
        }

        private static void ValidateDay(DateTime date)
        {
            if(date.Month == 12 && date.Day>0 && date.Day < 26)
            {
                return;
            }
            throw new ArgumentException(nameof(date), "Unsuported date.");
        }
    }
}
