using System.Collections.Generic;
using UnityEngine;

public static class Pathfinder
{
    public delegate bool isValidMoveDelegate(int x, int y, bool inclusive = false);
    public delegate float costDelegate(int x, int y);

    public static List<Vector2Int> FindPath(Vector2Int source, Vector2Int destination, isValidMoveDelegate isValidMove, costDelegate cost)
    {
        PriorityQueue<Vector2Int> openSet = new PriorityQueue<Vector2Int>();
        openSet.Enqueue(source,0);

        Dictionary<Vector2Int,Vector2Int> path = new Dictionary<Vector2Int,Vector2Int>();

        Dictionary<Vector2Int, float> gScore = new Dictionary<Vector2Int, float>();
        gScore[source] = 0;

        Dictionary<Vector2Int,float> fScore = new Dictionary<Vector2Int,float>();
        fScore[source] = Heuristic(source, destination);

        while (openSet.Count > 0) {
            Vector2Int cur = openSet.Dequeue();

            if (cur == destination)
            {
                return ReconstructPath(path, destination);
            }

            foreach (var (dx, dy) in new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) }) {
                var newX = cur.x + dx;
                var newY = cur.y + dy;

                if (isValidMove(newX, newY, true)) {
                    Vector2Int neighbor = new Vector2Int(newX,newY);
                    float tempGScore = gScore[cur] + cost(newX,newY);

                    if (!gScore.ContainsKey(neighbor) || gScore[neighbor] > tempGScore) {
                        gScore[neighbor] = tempGScore;
                        fScore[neighbor] = tempGScore + Heuristic(neighbor,destination);
                        path[neighbor] = cur;

                        if (!openSet.Contains(neighbor)) {
                            openSet.Enqueue(neighbor, fScore[neighbor]);
                        }
                    }

                }
            }
        }

        return null;
    }

    private static float Heuristic(Vector2Int cur, Vector2Int destination) {
        return Mathf.Abs(destination.x - cur.x) + Mathf.Abs(destination.y - cur.y);
    }

    private static List<Vector2Int> ReconstructPath(Dictionary<Vector2Int,Vector2Int> path, Vector2Int destination) {
        Vector2Int cur = destination;
        List<Vector2Int> totalPath = new List<Vector2Int>() { cur };

        while (path.ContainsKey(cur)) {
            cur = path[cur];
            totalPath.Add(cur);
        }

        totalPath.Reverse();

        return totalPath;
    }
}
