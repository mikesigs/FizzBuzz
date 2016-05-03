using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzz.Core
{
    public class FizzBuzz
    {
        private readonly Dictionary<int, string> _divisorMap;

        public FizzBuzz(Dictionary<int, string> divisorMap)
        {
            _divisorMap = divisorMap;
        }

        public string Parse(int i)
        {
            var messages =
                _divisorMap
                       .Where(map => i % map.Key == 0)
                       .Select(mapping => mapping.Value)
                       .ToList();

            return !messages.Any() ? i.ToString() : String.Join(" ", messages);
        }
    }
}
