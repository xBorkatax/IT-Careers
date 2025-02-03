using System;
using System.Collections.Generic;
using System.Linq;

namespace Mikado
{
    internal class Program
    {
        static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        static bool[] visited;
        static Stack<int> route = new Stack<int>();
        static void DFS(int node)
        {
            visited[node] = true;
            bool allVisited = true;
            route.Push(node);

            for (int i = 0; i < visited.Length; i++)
            {
                if (visited[i] == false)
                {
                    allVisited = false;
                }
            }

            if (allVisited == true && route.Count == visited.Length)
            {
                String answer = route.Pop().ToString();
                while (route.Count > 0)
                {
                    answer = route.Pop() + " -> " + answer;
                }
                Console.WriteLine(answer);
            }
                

            for (int i = 0; i < graph[node].Count; i++)
            {
                if (visited[graph[node][i]] == false)
                {
                    DFS(graph[node][i]);
                }
            }

            visited[node] = false;

            if (route.Count > 0)
            {
                route.Pop();
            }
        }

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                graph.Add(i, new List<int>());
            }

            bool[] possibleStartingPoints = new bool[N];
            visited = new bool[N];

            for (int i = 0; i < N; i++)
            {
                possibleStartingPoints[i] = true;
                visited[i] = false;
            }

            do
            {
                string input = Console.ReadLine();

                if (input == "hopstop")
                {
                    break;
                }

                string[] inputSplit = input.Split(' ');
                int stickOver = int.Parse(inputSplit[0]);
                int stickUnder = int.Parse(inputSplit[1]);
                possibleStartingPoints[stickUnder] = false;
                graph[stickOver].Add(stickUnder);
            } while (true);

            List<int> startingPoints = new List<int>();

            for (int i = 0; i < N; i++)
            {
                if (possibleStartingPoints[i] == true)
                {
                    startingPoints.Add(i);
                }
            }

            for (int i = 0; i < startingPoints.Count; i++)
            {
                for (int j = 0; j < startingPoints.Count; j++)
                {
                    if (i == j)
                        continue;

                    graph[startingPoints[i]].Add(startingPoints[j]);
                }
            }

            startingPoints.Sort();
            startingPoints.ForEach(element => 
            {
                DFS(element);

                for (int i = 0; i < N; i++)
                {
                    visited[i] = false;
                }
                
                while (route.Count > 0)
                {
                    route.Pop();
                }
            }
            );
        }
    }
}