public static class NumberDissector 
{
    // Time complexity: O(n^3), 
    // or quicker depending on when the algorithm has found the required amount of trios.
    public static bool FindTrios(
        in int magicNumber, 
        in List<int> input, 
        in int numberOfTriosToFind, 
        out List<List<int>> output) 
    {
        output = new List<List<int>>();

        if (!input.Any() || input.Count() % 3 != 0)
            throw new ArgumentException(nameof(input), "Input list is invalid.");

        Console.WriteLine("Input: ");
        foreach (var number in input) 
        {
            Console.Write(number + ", ");
        }
        Console.WriteLine();

        for (int i = 0; i < input.Count; i++) 
        {
            for (int j = i + 1; j < input.Count; j++) 
            {
                for (int k = j + 1; k < input.Count; k++)
                {
                    if (input[i] + input[j] + input[k] == magicNumber) 
                    {
                        output.Add(new List<int>() { input[i], input[j], input[k] });
                        if (output.Count() == numberOfTriosToFind) 
                            return true;
                    }
                }
            }
        }
        
        return (output.Count == numberOfTriosToFind);
    } 
}