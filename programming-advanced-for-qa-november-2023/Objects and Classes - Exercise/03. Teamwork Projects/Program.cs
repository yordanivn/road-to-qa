namespace _03._Teamwork_Projects
{
    public class Program
    {
        static void Main(string[] args)
        {

            int countOfTeams=int.Parse(Console.ReadLine());
            Dictionary<string,Team> teams = new Dictionary<string,Team>();

            for (int i = 1; i <= countOfTeams; i++)
            {
                string[] input = Console.ReadLine().Split("-");
                string creator = input[0];
                string teamName = input[1];
                //string member = input[2];
                Team currentTeam = new Team(teamName, creator);

                if (teams.ContainsKey(teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(t => t.Value.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    teams.Add(teamName, currentTeam);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
                
            }

            string command=Console.ReadLine();
            while(command != "end of assignment")
            {
                string[] commandArr = command.Split(" -> ");
                string memberToJoin = commandArr[0];
                string teamToJoin= commandArr[1];

                if(!teams.ContainsKey(teamToJoin))
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    continue;
                }
                var userIsCreator = teams[teamToJoin].Creator == memberToJoin;
                var userAlreadyMember=teams.Values.Any(t=>t.Members.Contains(memberToJoin));
                if (userIsCreator||userAlreadyMember)
                {
                    Console.WriteLine($"Member {memberToJoin} cannot join team {teamToJoin}!");
                    continue;
                }
                teams[teamToJoin].Members.Add(memberToJoin);
               
                command=Console.ReadLine();

            }
            var validTeams = teams.Where(t => t.Value.Members.Count > 0).OrderBy(t => t.Value.TeamName).ToDictionary(t=>t.Key,t=>t.Value);

            var emptyTeams=teams.Where(t=>t.Value.Members.Count==0).OrderBy(t=>t.Value.TeamName).ToDictionary(t=>t.Key,t=>t.Value);
            
            foreach(var team in validTeams.Values.OrderByDescending(t=>t.Members.Count))
            {
                Console.WriteLine(team.TeamName);
                Console.WriteLine($"- {team.Creator}");

                foreach(var member in team.Members.OrderBy(m=>m))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var emptyTeam in emptyTeams.Values)
            {
                Console.WriteLine($"{emptyTeam.TeamName}");
            }
            //foreach (var team in teams.Where(team=>team.Value.Members.Count>0).OrderByDescending(team=>team.Value.Members.Count).ThenBy(team=>team.Key))
            //{
            //    Console.WriteLine(team.Key);
            //    Console.WriteLine("-- "+team.Value.Creator);
            //    foreach(string member in team.Value.Members.OrderBy(m=>m))
            //    {
            //        Console.WriteLine("-- "+ member );
            //    }
            //}
            //Console.WriteLine("Teams to disband: ");
            //foreach (var team in teams.Where(team=>team.Value.Members.Count==0))
            //{
            //    Console.WriteLine(team.Key);
            //}
        }
    }
}

public class Team
{
    public Team(string teamName, string creator)
    {
        TeamName = teamName;
        Creator = creator;
        Members = new List<string>();
    }

    public string TeamName { get; set; }
    public string Creator { get; set; }
    public List<string> Members { get; set; }

}