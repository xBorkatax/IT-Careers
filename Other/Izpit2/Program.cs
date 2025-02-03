namespace Izpit2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> graph = new Dictionary<string, HashSet<string>>();

            int stick = int.Parse(Console.ReadLine());

            for (int i = 0; i < stick; i++)
            {
                graph[i.ToString()] = new HashSet<string>();
            }

            string input = "";
            while ((input = Console.ReadLine()) != "hopstop")
            {
                string[] inputParams = input.Split();

                string parent = inputParams[0];
                string child = inputParams[1];
                graph[parent].Add(child);
            }

            List<string> paths = new List<string>();
            List<string> sticks = Findstickabove(graph, paths, stick);
            foreach (string element in sticks)
            {
                paths = Reshenie(graph, paths, stick, element);
                Console.WriteLine(string.Join(" -> ", paths));
                paths.Clear();
            }
        }
        static List<string> Reshenie(Dictionary<string, HashSet<string>> graph, List<string> path, int stick, string element)
        {
            Dictionary<string, HashSet<string>> updatedGraph = new Dictionary<string, HashSet<string>>(graph);

            if (updatedGraph.ContainsKey(element))
            {
                updatedGraph.Remove(element);
                path.Add(element);
                path = Reshenie(updatedGraph, path, stick, element);
            }
            else
            {
                List<string> sticks = Findstickabove(updatedGraph, path, stick);
                if (updatedGraph.Count > 0)
                {
                    updatedGraph.Remove(sticks[0]);
                    path.Add(sticks[0]);
                    path = Reshenie(updatedGraph, path, stick, element);
                }
            }
            return path;
        }
        static List<string> Findstickabove(Dictionary<string, HashSet<string>> graph, List<string> path, int stick)
        {
            List<string> sticks = new List<string>();
            for (int i = 0; i < stick; i++)
            {
                sticks.Add(i.ToString());
            }
            if (path.Count > 0)
            {
                foreach (string element in path)
                {
                    sticks.Remove(element);
                }
            }
            foreach (KeyValuePair<string, HashSet<string>> node in graph)
            {
                foreach (string element in node.Value)
                {
                    if (sticks.Contains(element))
                    {
                        sticks.Remove(element);
                    }
                }
            }
            return sticks;
        }
    }
}