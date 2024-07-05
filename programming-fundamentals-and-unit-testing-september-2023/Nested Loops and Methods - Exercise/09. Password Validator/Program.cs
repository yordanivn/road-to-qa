using System;
using System.Text.RegularExpressions;

static bool PasswordLenght(string pass, bool isPasswordValid)
{
    if (pass.Length >= 6 && pass.Length < 10)
    {
        return isPasswordValid = true;
    }
    else return isPasswordValid = false;
}

static bool PasswordOnlyDigitsAndLetters(string pass, bool isPasswordValid)
{
    Regex regex = new Regex("^[a-zA-Z0-9]+$");
    bool containsOnlyLettersAndDigits = regex.IsMatch(pass);
    if (containsOnlyLettersAndDigits) return isPasswordValid = true;
    else return isPasswordValid = false;
}

static bool PasswordAtLeast2Digits(string pass, bool isPasswordValid)
{
    Regex regex = new Regex("^(?=.*[0-9].*[0-9]).*$");
    bool containsOnlyLettersAndDigits = regex.IsMatch(pass);
    if (containsOnlyLettersAndDigits) return isPasswordValid = true;
    else return isPasswordValid = false;
}

String password = Console.ReadLine();
bool isPasswordValid=false;
if(PasswordLenght(password, isPasswordValid)==true && PasswordOnlyDigitsAndLetters(password,isPasswordValid)==true)
{
    Console.WriteLine("Password is valid"); 
}
if(PasswordLenght(password,isPasswordValid)==false)
{
    Console.WriteLine("Password must be between 6 and 10 characters"); ;
}
if(PasswordOnlyDigitsAndLetters(password, isPasswordValid) == false)
{
    Console.WriteLine("Password must consist only of letters and digits");
}
if(PasswordAtLeast2Digits(password,isPasswordValid)==false)
{
    Console.WriteLine("Password must have at least 2 digits");
}