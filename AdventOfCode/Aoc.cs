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
        readonly HttpClient _client;

        public Aoc(string session)
        {
            var baseUri = new Uri("https://adventofcode.com");
            var c = new CookieContainer();
            c.Add(baseUri, new Cookie("session", session));
            _client = new HttpClient(new HttpClientHandler() { CookieContainer = c }) { BaseAddress = baseUri };
        }

        public async Task<string> GetInput(int year, int day, CancellationToken cancellationToken = default)
        {
            var pathFile = $"cache/{year}{day,00}.txt";
            if (!File.Exists(pathFile))
            {
                if (!Directory.Exists($"cache"))
                {
                    Console.WriteLine("Creating cache folder.");
                    Directory.CreateDirectory($"cache");
                }
                Console.WriteLine($"Downloading puzzle for {year}{day,00}");
                var result = await _client.GetStringAsync($"/{year}/day/{day}/input", cancellationToken).ConfigureAwait(false);
                await File.WriteAllTextAsync(pathFile, result, cancellationToken).ConfigureAwait(false);
                return result;
            }
            else
            {
                return await File.ReadAllTextAsync(pathFile, cancellationToken).ConfigureAwait(false); ;
            }
        }
    }
}
