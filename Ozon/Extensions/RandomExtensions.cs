using System;
using System.Collections.Generic;
using System.Linq;

namespace Ozon.Extensions
{
    public static class RandomExtensions
    {
        #region Presets

        private static readonly IReadOnlyList<string> Names = new List<string>()
        {
            "Sergio",
            "Paolo",
            "Michael",
            "Alex",
            "Karim",
            "Sofia",
            "Anastasia",
            "Daria",
            "Lizetta",
            "Polly",
            "Sid",
        };

        private static readonly IReadOnlyList<string> Surnames = new List<string>()
        {
            "Brown",
            "Gallway",
            "London",
            "Baretta",
            "Coen",
            "Rosengold",
            "Smith",
            "Cubric",
            "Capolla",
            "Garolt",
            "Dumper",
            "Promer",
            "Bale",
            "Lloid",
        };

        private static readonly IReadOnlyList<string> _goodsNames = new List<string>()
        {
            "Electroguitar",
            "Artmaster markers",
            "pencils set",
            "Professional scissors",
            "External sound system for iPhone",
            "Charger for iPod",
            "Gucci T-shirt",
            "Sunglasses",
            "My Little Pony cup",
            "Audio disk of Nightwis",
            "Witcher Wildhunt artbook",
        };

        private static readonly IReadOnlyList<string> _emailEndings = new List<string>()
        {
            "inbox.ru",
            "gmail.com",
            "bk.ru",
            "yandex.ru",
            "bing.com",
            "qoollo.com",
            "softpolice.com",
            "mail.ru",
            "student.bmstu.ru",
        };

        #endregion

        /// <summary>
        /// Creates a random name of a person including first name and surname.
        /// </summary>
        /// <param name="random">An existing Randomizer.</param>
        /// <returns>A random full name.</returns>
        public static string NextName(this Random random)
        {
            return $"{Names[random.Next(Names.Count)]} {Surnames[random.Next(Surnames.Count)]}";
        }

        public static string NextGoodName(this Random random)
        {
            return _goodsNames[random.Next(_goodsNames.Count)];
        }

        public static decimal NextPrice(this Random random)
        {
            return (decimal)random.Next(1000000) / 100;
        }

        public static double NextPercent(this Random random)
        {
            return random.NextDouble() * 100;
        }

        /// <summary>
        /// Returns a bool value that is true with percent argument probability.
        /// </summary>
        /// <param name="random">An existing Randomizer.</param>
        /// <param name="percent">The probability of true value returned.</param>
        /// <returns>True or false value ralated to percentage of probability.</returns>
        public static bool Probability(this Random random, double percent)
        {
            if (percent < 0 || percent > 100)
                throw new ArgumentException("Percent argument must be in range of 0 and 100");

            return random.NextPercent() <= percent;
        }

        public static string NextEmail(this Random random)
        {
            return random.NextEmail(random.NextName());
        }

        public static string NextEmail(this Random random, string name)
        {
            name = name.ToLower().Replace(" ", "");

            if (random.Probability(20))
                name += random.Next(5000).ToString();

            string ending = _emailEndings[random.Next(_emailEndings.Count)];

            return $"{name}@{ending}";
        }

        public static string NextPhone(this Random random)
        {
            return $"+7 (9{random.NextDigits(2)}) {random.NextDigits(3)}-{random.NextDigits(2)}-{random.NextDigits(2)}";
        }

        public static char NextDigit(this Random random)
        {
            return random.Next(10).ToString()[0];
        }

        public static string NextDigits(this Random random, int count)
        {
            return new string(new object[count].Select(fake => random.NextDigit()).ToArray());
        }
    }
}
