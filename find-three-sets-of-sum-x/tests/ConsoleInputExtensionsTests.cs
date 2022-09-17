using FluentAssertions;
using Xunit;

namespace tests;

public class ConsoleInputExtensionsTests
{
    [Fact]
    public void ToNumberSet_WithAllNumbersInput_ShouldReturnFullList()
    {
        var input = "1 2 3 4 14 10 22";
        var output = input.ToNumberSet();

        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(7)
            .And.Equal(1, 2, 3, 4, 14, 10, 22);
    }

    [Fact]
    public void ToNumberSet_WithNumbersAndStrings_ShouldReturnPartialList() {
        var input = "1 2 4 abc 33 69";
        var output = input.ToNumberSet();

        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(5)
            .And.Equal(1, 2, 4, 33, 69);
    }

    [Fact]
    public void ToNumberSet_WithOnlyStrings_ShouldReturnEmptyList() {
        var input = "abc abc abc";
        var output = input.ToNumberSet();

        output
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void ToNumberSet_WithEmptyInput_ShouldReturnEmptyList() {
        var input = "";
        var output = input.ToNumberSet();

        output
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void ToNumberSet_WithDamagedNumbers_ShouldIgnoreThoseNumbers() {
        var input = "2b 3c 1a 22 39";
        var output = input.ToNumberSet();

        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(2)
            .And.Equal(22, 39);
    }

    [Fact]
    public void ToNumberSet_WithOverflowNumber_ShouldIgnoreThatNumber() {
        var input = "99999999999999999999999999999999999999999999 99 124";
        var output = input.ToNumberSet();

        output  
            .Should()
            .NotBeEmpty()
            .And.HaveCount(2)
            .And.Equal(99, 124);
    }
}