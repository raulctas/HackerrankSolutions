﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementaciones
{
    class ProgramDijkstraAlgoritm
    {
        static int[] DijkstraAlgoritm(int[,] graph, int source, int verticesCount)
        {
            int[] distances = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distances[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distances[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distances, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] &&
                        Convert.ToBoolean(graph[u, v]) &&
                        distances[u] != int.MaxValue &&
                        distances[u] + graph[u, v] < distances[v]
                        )
                        distances[v] = distances[u] + graph[u, v];
            }

            return distances;
        }

        static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MinValue;
            int minIndex = 0;
            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}
