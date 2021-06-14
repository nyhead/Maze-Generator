using System.Collections.Generic;
using System;

class Solver {
    //choose solver algorithm
    //get solution from solver algorithm

    public enum Profile {DFS, BFS};
    public (int x, int y)[] result;

    public Solver(Maze maze, Profile choice) {
        result = choice switch {
            Profile.DFS => DepthFirstSearch(maze),
            Profile.BFS => BreadthFirstSearch(maze)
        };
    }

    (int x, int y)[] DepthFirstSearch(Maze maze) {

        var start = maze.start;
        var end = maze.end;
        int width = maze.cols, height = maze.rows;
        
        Stack<(int x, int y)> stack = new Stack<(int x, int y)>();
        (int x, int y)[] path = new (int x, int y)[width * height];
        bool[,] visited = new bool[width , height];

        stack.Push(start);
        while (stack.Count > 0) {
            var curr = stack.Pop();

            if (curr == end) {
                break;
            }

            visited[curr.x, curr.y] = true;


            foreach (var neighbor in maze.get_adjacent(curr, visited)) {
                if (neighbor != (0,0)) {
                    stack.Push(neighbor);
                    path[neighbor.x + neighbor.y * width] = curr;
                }
            }
        }

        return path;
    }

    (int x, int y)[] BreadthFirstSearch(Maze maze) {
        
        var start = maze.start;
        var end = maze.end;
        int width = maze.cols, height = maze.rows;

        Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
        (int x, int y)[] path = new (int x, int y)[width * height];
        bool[,] visited = new bool[width , height];        

        visited[start.x, start.y] = true;

        queue.Enqueue(start);

        while (queue.Count > 0) {
            var curr = queue.Dequeue();

            if (curr == end) break;

            foreach (var neighbor in maze.get_adjacent(curr, visited)) {
                if (neighbor != (0,0)) {
                    queue.Enqueue(neighbor);
                    visited[neighbor.x, neighbor.y] = true;
                    path[neighbor.x + neighbor.y * width] = curr;
                }
            }
        }

        return path;
    }
}
