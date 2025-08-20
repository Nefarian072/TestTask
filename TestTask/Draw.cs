using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask;

public class Draw
{
    private readonly List<Athlete> _athletes;

    public Draw(IEnumerable<Athlete> athletes)
    {
        _athletes = athletes.ToList();
    }


    public List<Athlete>? Arrange()
    {
        var groups = _athletes
            .GroupBy(a => a.Team)
            .ToDictionary(g => g.Key, g => new Queue<Athlete>(g));

        int n = _athletes.Count;
        if (groups.Values.Max(g => g.Count) > (n + 1) / 2)
            return null;

        var pq = new PriorityQueue<string, int>();
        foreach (var kv in groups)
        {
            pq.Enqueue(kv.Key, -kv.Value.Count);
        }

        var result = new List<Athlete>();
        string lastTeam = null;

        while (pq.Count > 0)
        {
            var team1 = pq.Dequeue();

            if (team1 == lastTeam && pq.Count > 0)
            {
                var team2 = pq.Dequeue();
                var athlete2 = groups[team2].Dequeue();
                result.Add(athlete2);
                lastTeam = team2;

                if (groups[team2].Count > 0)
                    pq.Enqueue(team2, -groups[team2].Count);

                pq.Enqueue(team1, -groups[team1].Count);
            }
            else
            {
                var athlete1 = groups[team1].Dequeue();
                result.Add(athlete1);
                lastTeam = team1;

                if (groups[team1].Count > 0)
                    pq.Enqueue(team1, -groups[team1].Count);
            }
        }

        return result;
    }
}