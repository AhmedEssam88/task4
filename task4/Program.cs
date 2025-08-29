namespace task4
{
    class NoVowelException : Exception
    {
        public NoVowelException(string message) : base(message)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a string:");
                string input = Console.ReadLine();

                CheckForVowels(input);

                Console.WriteLine("The input contains at least one vowel.");
            }
            catch (NoVowelException ex)
            {
                Console.WriteLine($"Vowel check failed: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Invalid input: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        static void CheckForVowels(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or empty.");
            }

            string vowels = "aeiouAEIOU";
            foreach (char c in input)
            {
                if (vowels.Contains(c))
                {
                    return; 
                }
            }

            throw new NoVowelException("The input string contains no vowels.");
        }
    }


   
}
  
