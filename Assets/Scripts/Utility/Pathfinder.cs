using System.Collections.Generic;
using UnityEngine;

public static class Pathfinder
{
    public delegate bool isValidMoveDelegate(int x, int y, bool inclusive = false);

    public static List<Vector2Int> FindPath(Vector2Int source, Vector2Int destination, isValidMoveDelegate isValidMove)
    {
        List<Vector2Int> openSet = new List<Vector2Int> { source };

        while (openSet.Count > 0) {
            Vector2Int cur = openSet[0];

            // TODO

            openSet.Remove(cur);

            if (cur == destination)
            {
                return RetracePath(source, destination);
            }

            foreach (var (dx, dy) in new (int, int)[] { (-1, 0), (1, 0), (0, -1), (0, 1) }) {
                var newX = cur.x + dx;
                var newY = cur.y + dy;
                Vector2Int neighbor = new Vector2Int(newX,newY);
                if (isValidMove(newX, newY, true)) {
                    // TODO
                    if (!openSet.Contains(neighbor))
                        openSet.Add(neighbor);
                }
            }
        }

        return null;
    }

    private static List<Vector2Int> RetracePath(Vector2Int source, Vector2Int destination) {
        // TODO
        return null;
    }
}
