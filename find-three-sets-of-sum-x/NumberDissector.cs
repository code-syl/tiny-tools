public static class NumberDissector 
{
    public static bool FindTrios(
        int magicNumber, 
        List<int> input, 
        int numberOfTriosToFind, 
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
