using System;
using System.Collections.Generic;
using System.Text;

namespace SomeResolver.ExampleApp.Services
{
    public class RandomNumberGenerator
    {
        public int GenerateNumber()
        {
            var random = new Random();
            return random.Next(1, 100);
        }
    }
}
