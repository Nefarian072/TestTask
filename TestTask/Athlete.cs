using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask;

public class Athlete
{
    public string Name { get; }
    public string Team { get; }
    public string FullInfo => $"{Name},{Team}";

    public Athlete(string name, string team)
    {
        Name = name;
        Team = team;
    }
}
