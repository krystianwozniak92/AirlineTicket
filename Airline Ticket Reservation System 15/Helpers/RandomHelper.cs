using System;
using System.Text;

namespace Helpers
{
    public static class RandomHelper
    {
        /// <summary>
        /// Returns random case-sensitive string containing digits and letters.
        /// </summary>
        /// <param name="length">String length.</param>
        /// <returns></returns>
        public static string GetRandomString(int length = 25)
        {
            Random generator = new Random();
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                switch (generator.Next(1, 4))
                {
                    case 1:
                        builder.Append((char)generator.Next(65, 91));
                        break;
                    case 2:
                        builder.Append((char)generator.Next(97, 123));
                        break;
                    case 3:
                        builder.Append((char)generator.Next(48, 58));
                        break;
                }
            }

            return builder.ToString();
        }
    }
}
