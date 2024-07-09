Dictionary<string, List<string>> companies = new();

string input = Console.ReadLine();

while(input!="End")
{
    string[] intputArr = input.Split(" -> ");
    string companyName = intputArr[0];
    string employeeID = intputArr[1];

    if(!companies.ContainsKey(companyName))
    {
        companies.Add(companyName,new List<string>());
    }
    if(!companies[companyName].Contains(employeeID))
    {
        companies[companyName].Add(employeeID);
    }
    input= Console.ReadLine();
}
foreach(KeyValuePair<string, List<string>> currentCompany in companies)
{
   Console.WriteLine(currentCompany.Key);
    foreach(string currentEmpoyeeID in currentCompany.Value)
    {
        Console.WriteLine($"-- {currentEmpoyeeID}");
    }
}