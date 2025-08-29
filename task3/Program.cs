namespace task3
{
    class DuplicateNumberException : Exception
    {
        public DuplicateNumberException(string message) : base(message)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a list of integers separated by spaces:");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    throw new ArgumentException("Input cannot be empty.");
                }

                List<int> numbers = input
                    .Split(' ')
                    .Select(int.Parse)
                    .ToList();

                CheckForDuplicates(numbers);

                Console.WriteLine("All numbers are unique. No duplicates found.");
            }
            catch (DuplicateNumberException ex)
            {
                Console.WriteLine($"Duplicate detected: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter only integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void CheckForDuplicates(List<int> numbers)
        {
            HashSet<int> seen = new HashSet<int>();

            foreach (int number in numbers)
            {
                if (!seen.Add(number))
                {
                    throw new DuplicateNumberException($"The number {number} is duplicated.");
                }
            }
        }
    }

    
   
}
