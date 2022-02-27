using System;
using System.Collections.Generic;
using System.Linq;

namespace T05._Teamwork_Projects
{
    internal class Program
    {
        class Team
        {
            public Team(string creatorName, string teamName)
            {
                this.Creator = creatorName;
                this.Name = teamName;

                this.Members = new List<string>();
            }

            public string Creator { get; set; }

            public string Name { get; set; }

            public List<string> Members { get; set; }

            public void AddMember(string member)
            {
                this.Members.Add(member);
            }
        }

        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>(); 

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] teamArgs = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);

                string creator = teamArgs[0];
                string teamName = teamArgs[1];
                
                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Team team = new Team(creator, teamName);

                teams.Add(team);

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string command = Console.ReadLine();

            while (command != "end of assignment")
            {
                string[] cmdArgs = command.Split("->", StringSplitOptions.RemoveEmptyEntries);

                string member = cmdArgs[0];
                string teamToJoin = cmdArgs[1];

                Team searchedTeam = teams.FirstOrDefault(t => t.Name == teamToJoin);

                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamToJoin} does not exist!");
                    command = Console.ReadLine();
                    continue;
                }
                
                if (isAlreadyMember(teams, member))
                {
                    Console.WriteLine($"Member {member} cannot join team {searchedTeam.Name}!");
                    command = Console.ReadLine();
                    continue;
                }
                // Equivalent:
                //if (teams.Any(t => t.Members.Contains(member)))
                //{
                //    Console.WriteLine($"Member {member} cannot join team {searchedTeam.Name}!");
                //    command = Console.ReadLine();
                //    continue;
                //}

                if (teams.Any(t => t.Creator == member))
                {
                    Console.WriteLine($"Member {member} cannot join team {searchedTeam.Name}!");
                    command = Console.ReadLine();
                    continue;
                }

                searchedTeam.AddMember(member);

                command = Console.ReadLine();
            }

            List<Team> teamsWithMembers = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();

            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();

            foreach (Team team in teamsWithMembers)
            {
                Console.WriteLine($"{team.Name}\n- {team.Creator}");

                foreach (string member in team.Members.OrderBy(t => t))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in teamsToDisband)
            {
                Console.WriteLine(team.Name);
            }
        }

        static bool isAlreadyMember(List<Team> teams, string member)
        {
            foreach (var team in teams)
            {
                if (team.Members.Contains(member))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
