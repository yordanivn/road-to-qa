Dictionary<string, List<double>> studentDictionary = new();

int n = int.Parse(Console.ReadLine());

for(int i=0;i<n;i++)
{
    string studentName = Console.ReadLine();
    double grade = double.Parse(Console.ReadLine());

    if(!studentDictionary.ContainsKey(studentName))
    {
        studentDictionary.Add(studentName, new() { grade});
    }
    else
    {
        studentDictionary[studentName].Add(grade);
    }
}
var excallent= studentDictionary.Where(st => st.Value.Average() >= 4.50);

foreach (KeyValuePair<string, List<double>> pairs in excallent)
{
    Console.WriteLine($"{pairs.Key} -> {pairs.Value.Average():f2}");
}

