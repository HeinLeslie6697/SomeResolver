using SomeResolver.ExampleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SomeResolver.ExampleApp.Services
{
    public class StringReverser : IStringReverser
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            var reversed = new StringBuilder();

            for (int i = input.Length - 1; i > -1; i--)
                reversed.Append(input[i]);

            return reversed.ToString();
        }
    }
}
