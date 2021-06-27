using Cairo;
using System;

class Canvas {
    ImageSurface surface;

    Maze maze;
    Context ctx;

    public Canvas(Maze maze) {
        this.maze = maze;
        surface = new ImageSurface(Format.RGB24, this.maze.cols, this.maze.rows);
        ctx = new Context(surface);
    }

    public void draw_the_maze(Solver solver = null) {
        var grid = maze.grid;
        int width = grid.GetLength(0), height = grid.GetLength(1);

        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                (int r, int g, int b) color = !grid[x,y] ? (0,0,0) : (255,255,255);
                ctx.SetSourceRGB(color.r, color.g, color.b);
                ctx.Rectangle(x,y,1,1);
                ctx.Fill();
            }
        }

        if (solver is Solver) {
            var end = maze.end;
            var result = solver.result;

            var current = end;

            while (current != (0,0)) {
                ctx.SetSourceRGB(255, 0, 0);
                ctx.Rectangle(current.x,current.y,1,1);
                ctx.Fill();                    
                current = result[current.x + current.y * width];
            }                      
        }
    }

    public void save_image(string filename) {
        surface.WriteToPng(filename);
    }
}