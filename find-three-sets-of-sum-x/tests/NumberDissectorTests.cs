using FluentAssertions;
using Xunit;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace tests;

public class NumberDissectorTests 
{
    private const int MagicNumber = 10;

    [Fact]
    public void FindTrios_WithEmptyInput_ShouldThrowException() 
    {
        // Arrange
        var input = new List<int>();

        // Act
        var action = () => NumberDissector.FindTrios(MagicNumber, input, 3, out _);

        // Assert
        action  
            .Should()
            .Throw<ArgumentException>();
    }

    [Fact]
    public void FindTrios_WithListCountNotDivisibleByThree_ShouldThrowException() 
    {
        // Arrange
        var input = new List<int>() { 1, 2 };

        // Act
        var action = () => NumberDissector.FindTrios(MagicNumber, input, 3, out _);

        // Assert
        action
            .Should()
            .Throw<ArgumentException>();
    }

    [Fact]
    public void FindTrios_WhenAskingForALimitedSetOfAnswers_ShouldReturnTrueAndLimitedSet() 
    {
        // Arrange
        var input = new List<int>() { 3, 3, 4, 8, 1, 1 };
        var requestedNumberOfTrios = 1;

        // Act
        var result = NumberDissector.FindTrios(
            MagicNumber,
            input,
            requestedNumberOfTrios,
            out var output
        );

        // Assert
        result  
            .Should()
            .BeTrue();

        output
            .Should()
            .HaveCount(1)
            .And.OnlyContain(subset => subset.Sum() == MagicNumber);
    }

    [Fact]
    public void FindTrios_WhenNoTriosAreFound_ShouldReturnFalseAndEmptyList() 
    {
        // Arrange
        var input = new List<int>() { 3, 3, 3 };
        var requestedNumberOfTrios = 1;

        // Act
        var result = NumberDissector.FindTrios(
            MagicNumber,
            input,
            requestedNumberOfTrios,
            out var output
        );

        // Assert
        result
            .Should()
            .BeFalse();
        
        output
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void FindTrios_WhenNotEnoughTriosAreFound_ShouldReturnFalseAndALimitedSet() 
    {
        // Arrange
        var input = new List<int>() { 7, 2, 1, 1, 1, 1 };
        var requestedNumberOfTrios = 2;

        // Act
        var result = NumberDissector.FindTrios(
            MagicNumber,
            input,
            requestedNumberOfTrios,
            out var output
        );

        // Assert
        result
            .Should()
            .BeFalse();
        
        output
            .Should()
            .NotBeEmpty()
            .And.HaveCount(1)
            .And.OnlyContain(subset => subset.Sum() == MagicNumber);
    }
}