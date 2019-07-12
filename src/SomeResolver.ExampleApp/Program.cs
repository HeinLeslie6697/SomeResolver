using SomeResolver.ExampleApp.Interfaces;
using SomeResolver.ExampleApp.Services;
using System;

namespace SomeResolver.ExampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = new DependencyCollection()
                .RegisterDependency<IStringReverser, StringReverser>()
                .RegisterDependency<IPalindromeDetector, PalindromeDetector>()
                .RegisterDependency<RandomNumberGenerator>()
                .BuildDependencyProvider();

            var reverser = provider.GetDependency<IStringReverser>();
            var detector = provider.GetDependency<IPalindromeDetector>();
            var rngGenerator = provider.GetDependency<RandomNumberGenerator>();

            Console.WriteLine(reverser.Reverse("Some reversed string."));

            Console.WriteLine($"Is \"Racecar\" a palidrome: {detector.IsPalidrome("racecar")}");
            Console.WriteLine($"Is \"notapalidrome\" a palidrome: {detector.IsPalidrome("notapalidrome")}");
            Console.WriteLine($"A random number: {rngGenerator.GenerateNumber()}");

            Console.ReadKey();
        }
    }
}
