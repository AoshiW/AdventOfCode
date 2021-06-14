using System.Text.Json;
using System.Text.Json.Node;

namespace AdventOfCode.Y2015
{
    public class D12 : BaseDay
    {
        public D12(string input) : base(2015, 12, input)
        {

        }

        /// <inheritdoc/>
        public override string Part1()
        {
            var json = JsonSerializer.Deserialize<JsonNode>(Input);
            return GetSum(json).ToString();
        }

        static int GetSum(JsonNode node)
        {
            int sum = 0;
            if (node is JsonArray arr)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    sum += GetSum(arr[i]);
                }
            }
            else if (node is JsonObject obj)
            {
                foreach (var item in obj)
                {
                    sum += GetSum(item.Value);
                }
            }
            else
            {
                node.AsValue().TryGetValue(out sum);
            }
            return sum;
        }

        /// <inheritdoc/>
        public override string Part2()
        {
            var json = JsonSerializer.Deserialize<JsonNode>(Input);
            return GetSum2(json).ToString();
        }


        static int? GetSum2(JsonNode node)
        {
            int sum = 0;
            if (node is JsonArray arr)
            {
                for (int i = 0; i < arr.Count; i++)
                {
                    var val = GetSum2(arr[i]);
                    sum += val.HasValue ? val.Value : 0;
                }
            }
            else if (node is JsonObject obj)
            {
                foreach (var item in obj)
                {
                    var val = GetSum2(item.Value);
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
