//var input = new List<int>() { 9, 15, 3, 10, 5, 14, 6, 16, 11 };
//const int magicNumber = 22;

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



Console.ReadKey();