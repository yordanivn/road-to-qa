using System.ComponentModel.Design;

Dictionary<string, string> registers = new();

int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    string[] inputArr = Console.ReadLine().Split().ToArray();
    string comand = inputArr[0];
    string employee = inputArr[1];

    if(comand=="register")
    {
        string plateNumber = inputArr[2];
        if(!registers.ContainsKey(employee))
        {
            registers.Add(employee, plateNumber);
            Console.WriteLine($"{employee} registered {plateNumber} successfully");
        }
        else 
        {
            Console.WriteLine($"ERROR: already registered with plate number {registers[employee]}");
        }
    }
    else if(comand== "unregister")
    {
        if(registers.ContainsKey(employee))
        {
            registers.Remove(employee);
            Console.WriteLine($"{employee} unregistered successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: user {employee} not found");
        }
    }
}

foreach (KeyValuePair<string, string> pair in registers)
{
    Console.WriteLine($"{pair.Key} => {pair.Value}");
}