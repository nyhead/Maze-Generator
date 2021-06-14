# Maze generation and solving

You can specify command-line options like this:
```
$ dotnet run -- [options]
```

To generate a maze, use -g option to specify width, height, and name of output file like this:
```
$ dotnet run -- -g <width> <height> <output_name>.png
```

To solve a maze, use -s option to specify the algorithm from dfs or bfs, name of the input file and output file like this:
```
$ dotnet run -- -s dfs/bfs <input_name>.png <output_name>.png 
```
Newly generated maze:   
![alt text](./examples/bitmap.png?raw=true)

Solved maze:           
![alt text](./examples/bitmap_solved.png?raw=true)
