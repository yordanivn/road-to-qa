using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hello";
        string expected = "olleH";

        // Act
        string result=_exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;
        

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        //Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 10.0m;

        //Act
        decimal result=_exceptions.ArgumentCalculateDiscount(totalPrice, discount);

        //Assert
        Assert.That(result,Is.EqualTo(90));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        //Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -10.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(()=>_exceptions.ArgumentCalculateDiscount(totalPrice,discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] array= { 1, 2, 3,4 };
        int index = 2;

        //Act
        int result=_exceptions.IndexOutOfRangeGetElement(array, index);

        //Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[] array = { 1, 2, 3, 4 };
        int index = -2;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        //Arrange
        int[] array = { 1, 2, 3, 4 };
        int index = 5;

        // Act & Assert
        Assert.That(()=> this._exceptions.IndexOutOfRangeGetElement(array,index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        //Arrange
        bool isLoggedIn = true;

        //Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(isLoggedIn);

        //Assert
        Assert.That(result, Is.EqualTo("User logged in."));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        //Arrange
        bool isLoggedIn = false;

        //Act & Assert
        Assert.That(()=>_exceptions.InvalidOperationPerformSecureOperation(isLoggedIn),Throws.InvalidOperationException);

    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        //Arrange
        string input = "1";

        //Act
        int result=_exceptions.FormatExceptionParseInt(input);

        //Assert
        Assert.That(result,Is.EqualTo(1));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        //Arrange
        string input = "p";

        //Act & Assert
        Assert.That(()=> _exceptions.FormatExceptionParseInt(input),Throws.InstanceOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> dictionary = new()
        {
            ["first"] = 10,
            ["second"] = 20,
            ["third"] = 30,
        };
        string key = "second";
        //Act
        int result=_exceptions.KeyNotFoundFindValueByKey(dictionary, key);

        //Assert
        Assert.That(result,Is.EqualTo(20));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> dictionary = new()
        {
            ["first"] = 10,
            ["second"] = 20,
            ["third"] = 30,
        };
        string key = "fifth";

        //Act & Assert
        Assert.That(()=>_exceptions.KeyNotFoundFindValueByKey(dictionary,key),Throws.InstanceOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        //Arrange
        int num1 = 1;
        int num2 = 2;

        //Act
        int result=_exceptions.OverflowAddNumbers(num1, num2);

        //Assert
        Assert.That(result,Is.EqualTo(3));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        //Arrange
        int num1 = int.MaxValue;
        int num2 = int.MaxValue;

        //Act & Arrange
        Assert.That(()=>_exceptions.OverflowAddNumbers(num1,num2),Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        //Arrange
        int num1 = int.MinValue;
        int num2 = int.MinValue;

        //Act & Arrange
        Assert.That(() => _exceptions.OverflowAddNumbers(num1, num2), Throws.InstanceOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        //Arrange
        int num1 = 9;
        int num2 = 3;

        //Act
        int result=_exceptions.DivideByZeroDivideNumbers(num1, num2);

        //Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        //Arrange
        int num1 = 9;
        int num2 = 0;

        //Act & Assert
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(num1, num2), Throws.InstanceOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        int[] array = { 1, 2, 3};
        int index = 2;

        int result=_exceptions.SumCollectionElements(array, index);

        Assert.That(result,Is.EqualTo(6));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        int[]? array = null;
        int index = 5;

        Assert.That(()=> _exceptions.SumCollectionElements(array,index), Throws.InstanceOf<ArgumentNullException>());
    }

    [Test]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException()
    {
        int[] array = { 1, 2, 3 };
        int index = 5;

        Assert.That(() => _exceptions.SumCollectionElements(array, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // TODO: finish test
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // TODO: finish test
    }
}
