using System.Text.Json;
using System.Text.Json.Node;

namespace AdventOfCode.Y2015
{
    public class Day12 : BaseDay<int>
    {
        public Day12(string input) : base(2015, 12, input)
        {

        }

        /// <inheritdoc/>
        public override int Part1()
        {
            var json = JsonSerializer.Deserialize<JsonNode>(Input);
            return GetSum(json!);
        }

        static int GetSum(JsonNode node)
        {
            int sum = 0;
            if (node is JsonArray arr)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    sum += GetSum(arr[i]!);
                }
            }
            else if (node is JsonObject obj)
            {
                foreach (var item in obj)
                {
                    sum += GetSum(item.Value!);
                }
            }
            else
            {
                node.AsValue().TryGetValue(out sum);
            }
            return sum;
        }

        /// <inheritdoc/>
        public override int Part2()
        {
            var json = JsonSerializer.Deserialize<JsonNode>(Input);
            return GetSum2(json!)!.Value;
        }


        static int? GetSum2(JsonNode node)
        {
            int sum = 0;
            if (node is JsonArray arr)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    sum += GetSum2(arr[i]!) ?? 0;
                }
            }
            else if (node is JsonObject obj)
            {
                foreach (var item in obj)
                {
                    var val = GetSum2(item.Value!);
                    if(val is null)
                    {
                        return 0;
                    }
                    sum += val.Value;
                }
            }
            else if (node.AsValue().TryGetValue(out sum))
            {

            }
            else if (node.GetValue<string>() == "red")
            {
                return null;
            }
            return sum;
        }
    }
}
