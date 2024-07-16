using System;

namespace PersonInfo;

public class Person
{
    private string _firstName;
    private string _lastName;
    private int _age;
    const int MIN_LENGTH = 3;

    public Person(string firstName,string lastName,int age)
    {
        this._firstName = firstName;
        this._lastName = lastName;
        this._age = age;
    }
    public string FirstName 
    { get { return _firstName; }
      set 
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"First name cannot contain fewer than {MIN_LENGTH} symbols!");
            }
            _firstName = value; 
        } 
    }

    public string LastName 
    { get { return _lastName; }
        set 
        {   if(value.Length<3)
            {
                throw new ArgumentException($"Last name cannot contain fewer than {MIN_LENGTH} symbols!");
            }
            _lastName = value; 
        } 
    }

    public int Age
    {
        get { return _age; }
        set 
        {   if (value <= 0)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            _age = value; 
        }
    }

    public override string ToString()
    {
        return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
}
}


