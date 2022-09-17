using FluentAssertions;
using Xunit;

namespace tests;

public class ConsoleInputExtensionsTests
{
    [Fact]
    public void ToNumberSet_WithAllNumbersInput_ShouldReturnFullList()
    {
        // Arrange
        var input = "1 2 3 4 14 10 22";

        // Act
        var output = input.ToNumberSet();

        // Assert
        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(7)
            .And.Equal(1, 2, 3, 4, 14, 10, 22);
    }

    [Fact]
    public void ToNumberSet_WithNumbersAndStrings_ShouldReturnPartialList() 
    {
        // Arrange
        var input = "1 2 4 abc 33 69";

        // Act
        var output = input.ToNumberSet();

        // Assert
        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(5)
            .And.Equal(1, 2, 4, 33, 69);
    }

    [Fact]
    public void ToNumberSet_WithOnlyStrings_ShouldReturnEmptyList() 
    {
        // Arrange
        var input = "abc abc abc";

        // Act
        var output = input.ToNumberSet();

        // Assert
        output
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void ToNumberSet_WithEmptyInput_ShouldReturnEmptyList() 
    {
        // Arrange
        var input = "";

        // Act
        var output = input.ToNumberSet();

        // Assert
        output
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void ToNumberSet_WithDamagedNumbers_ShouldIgnoreThoseNumbers() 
    {
        // Arrange
        var input = "2b 3c 1a 22 39";

        // Act
        var output = input.ToNumberSet();

        // Assert
        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(2)
            .And.Equal(22, 39);
    }

    [Fact]
    public void ToNumberSet_WithOverflowNumber_ShouldIgnoreThatNumber() 
    {
        // Arrange
        var input = "99999999999999999999999999999999999999999999 99 124";

        // Act
        var output = input.ToNumberSet();

        // Assert
        output  
            .Should()
            .NotBeEmpty()
            .And.HaveCount(2)
            .And.Equal(99, 124);
    }
}