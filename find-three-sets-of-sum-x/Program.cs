// 9 15 22 10 5 14 6 16 11
// 36

using Microsoft.VisualStudio.TestPlatform.Utilities;

Console.WriteLine(
    "Please enter your numbers separated by a space." + '\n' + 
    "The length of the list should be divisible by 3. (e.g. 3, 6, 9, etc...)");

var numbers = new List<int>();

while(true) 
{
    var input = Console.ReadLine().ToNumberSet();
    if (input.Count > 0 && input.Count % 3 == 0)
    {
        numbers = input;
        break;
    }

    Console.WriteLine(
        "Your list of numbers needs to have a multiple of 3 number entries." + '\n' +
        "Please check your numbers and try again.");
}

Console.WriteLine("How many trios do you want to find?");
var numberOfTriosToFind = 0;

while (true) 
{
    var valid = int.TryParse(Console.ReadLine(), out numberOfTriosToFind);

    if (valid)
        break;

    Console.WriteLine("Invalid entry, try again.");
}

Console.WriteLine("Please enter the sum you want to find.");

int magicNumber;

while (true) 
{
    var input = Console.ReadLine();
    if (int.TryParse(input, out var number))
    {
        magicNumber = number;
        break;
    }

    Console.WriteLine("Please check your input and try again.");
}

bool success = NumberDissector.FindTrios(magicNumber, numbers, 3, out var values);

Console.WriteLine($"The computation was {(success ? "successful" : "a failure")}.");
if (success)
{
    Console.WriteLine("The trios were:");
    foreach (var value in values)
    {
        foreach (var number in value)
            Console.Write($"{number}, ");
        Console.WriteLine();
    }
}