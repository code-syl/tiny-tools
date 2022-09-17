public static class ConsoleInputExtensions {
    public static List<int> ToNumberSet(this string? input) 
    {
        if (string.IsNullOrWhiteSpace(input)) 
            return Enumerable
                .Empty<int>()
                .ToList();
        
        var numbers = new List<int>();
        var chunks = input.Split(' ');
        foreach (var chunk in chunks)
            if (int.TryParse(chunk, out var number))
                numbers.Add(number);

        return numbers;
    }
}