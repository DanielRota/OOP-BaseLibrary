using System;

namespace BaseClass.Generics
{
    public class Generics
    {
        /// <summary>
        /// Generates a random <see cref="System.String"/> with the given lenght.
        /// </summary>
        /// <param name="lenght">The string's lenght.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="lenght"/> is <c>0</c> or less.
        /// </exception>
        public static string GenerateCode(int lenght)
        {
            if (lenght <= 0)
            {
                throw new ArgumentException($"The given lenght is equal or less of 0: {lenght}");
            }

            Random eleRandoms = new Random();

            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
            char[] chars = new char[5];

            for (int i = 0; i < lenght; i++)
            {
                chars[i] = allowedChars[eleRandoms.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        /// <summary>
        /// Returns an <see cref="System.Int32"/> intended as person's age.
        /// </summary>
        /// <param name="birthDate">The DateTime needed parameter.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="birthDate"/> is in the future.
        /// </exception>
        public static int GetAge(DateTime birthDate)
        {
            if (birthDate > DateTime.Now)
            {
                throw new ArgumentException("The given Date is wrong.");
            }

            TimeSpan ageTimeSpan = DateTime.UtcNow.Subtract(birthDate);
            int age = new DateTime(ageTimeSpan.Ticks).Year;
            return age;
        }
    }
}