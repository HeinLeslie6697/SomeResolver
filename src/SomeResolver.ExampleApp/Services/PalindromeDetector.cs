using SomeResolver.ExampleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SomeResolver.ExampleApp.Services
{
    public class PalindromeDetector : IPalindromeDetector
    {
        private readonly IStringReverser _reverser;

        public PalindromeDetector(IStringReverser reverser)
        {
            _reverser = reverser ?? throw new ArgumentNullException(nameof(reverser));
        }

        public bool IsPalidrome(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input), "An input string must be specified.");

            var reversedInput = _reverser.Reverse(input);

            return input.Equals(reversedInput, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
