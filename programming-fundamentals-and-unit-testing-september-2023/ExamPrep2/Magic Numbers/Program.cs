//int endNum = int.Parse(Console.ReadLine());

//bool foundMagincNUmber = false;

//bool IsPrime(int n)
//{
//    if (n <= 1) return false;
//    if (n <= 3) return true;
//    if (n % 2 == 0 || n % 3 == 0) return false;

//    return true;
//}
//bool IsMagicNumber(int num)
//{
//    int sumDigits = 0;
//    while(num > 0)
//    {
//        int digit = num % 10;
//        if(!IsPrime(digit))
//        {
//            return false;
//        }
//        sumDigits += digit;
//        num /= 10;
//    }
//    return sumDigits % 2 == 0;
//}

//for(int i=1; i<=endNum; i++)
//{
//    if (IsMagicNumber(i))
//    {
//        Console.Write(i + " ");
//        foundMagincNUmber = true;
//    }
//}

int n = int.Parse(Console.ReadLine());
bool isThereNoMatchingNumbers = true;

for(int i = 1; i <= n; i++)
{
    int workingNum = i;
    int digitSum = 0;
    bool isAllDigitsPrime = true;
    while(workingNum>0)
    {
        int digit = workingNum % 10;
        workingNum=workingNum/ 10;

        bool isDigitPrime = digit == 2 || digit == 3||digit==5||digit==7;

        if(isDigitPrime)
        {
            digitSum += digit;
        }
        else
        {
            isAllDigitsPrime=false;
            break;
        }
    }
    if(isAllDigitsPrime && digitSum%2==0)
    {
        Console.Write(i+" ");
        isThereNoMatchingNumbers=false;
    }
}
if(isThereNoMatchingNumbers)
{
    Console.WriteLine("no");
}