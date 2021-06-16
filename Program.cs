using System;
using static System.Console;

class Program {
    static void Main(string[] args) {          
      Maze maze = null;
      Solver solver = null;
      string out_filename = "";
      for (int i = 0 ; i < args.Length ; ++i) 
          switch (args[i]) {
              case "-g":
                  int width = int.Parse(args[i+1]), height = int.Parse(args[i+2]);
                  maze = new Maze(width, height);
                  out_filename = args[i+3];
                  i += 3;
                  break;
              case "-s":
                  Solver.Profile choice = args[i+1] == "dfs" ? Solver.Profile.DFS : args[i+1] == "bfs" ? Solver.Profile.BFS : Solver.Profile.Unknown;
                  maze = new Maze(args[i+2]);
                  solver = new Solver(maze, choice);
                  out_filename = args[i+3];
                  i += 3;
                  break;
              default:
                  WriteLine("ignored the option: " + args[i]);                  
                  break;
          } 

      if (maze is Maze) {
        Canvas canvas = new Canvas(maze);
        canvas.draw_the_maze(solver);
        canvas.save_image(out_filename);
        return;
      }
      
      WriteLine("usage: program [-g <w> <h> <output_filename>.png] [-s dfs/bfs <input_filename>.png <output_filename>.png]");          
    }    
}