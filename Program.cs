using System;
using static System.Console;

class Program {
    static void Main(string[] args) {  
      //args = new string[] {"-s", "dfs", "bitmap.png", "bitmap_solved.png"};   
      if (args.Length == 0) return;

      // -g w h output.png
      // -s algorithm input.png output.png 
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
                  maze = new Maze(args[i+2]);
                  var choice = args[i+1] == "dfs" ? Solver.Profile.DFS : Solver.Profile.BFS;
                  solver = new Solver(maze, choice);
                  out_filename = args[i+3];
                  i += 3;
                  break;
              default:
                  WriteLine("unknown option: " + args[i]);
                  WriteLine("usage: program [-g <w> <h> <output_filename>.png] [-s dfs/bfs <input_filename>.png <output_filename>.png]");
                  return;
          } 

      Canvas canvas = new Canvas(maze);
      canvas.draw_the_maze(solver);
      canvas.save_image(out_filename);
    }    
}