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

        var tries = 0;
        while (tries < numberOfTriosToFind) 
        {
            var running = true;
            while (running) 
            {
                for (int i = 0; i < input.Count && running; i++) 
                {
                    for (int j = i + 1; j < input.Count && running; j++) 
                    {
                        for (int k = j + 1; k < input.Count && running; k++)
                        {
                            if (input[i] + input[j] + input[k] == magicNumber) 
                            {
                                var values = new List<int>() { input[i], input[j], input[k] };
                                output.Add(values);
                                if (output.Count() == numberOfTriosToFind) 
                                    return true;

                                foreach (var value in values)
                                    input.Remove(value);

                                running = false;
                            }
                        }
                    }
                }
                
                running = false;
            }

            tries++;
        }
        
        
        return (output.Count == numberOfTriosToFind);
    } 
}