using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    public List<MazeCell> removingCells = new List<MazeCell>();
    public MazeCell[,] mazeCells = new MazeCell[height, width];
    public List<MazeCell> emptyCells = new List<MazeCell>();
    public int positionX;
    public int positionY;
    public GameObject[,] maze = new GameObject[height, width];
    public const int height = 10;
    public const int width = 10;      
    public List<MazeCell> allCells = new List<MazeCell>();    
    private bool allCellsVisited;
    private INeighbors neighbors;
    private IRemoveWall removeWall;
    private ICreatingDestination createStartAndFinish;
    private ICreatingWalls createWall;

    void Awake()
    {
        neighbors = GetComponent<INeighbors>();
        removeWall = GetComponent<IRemoveWall>();
        createStartAndFinish = GetComponent<ICreatingDestination>();
        createWall = GetComponent<ICreatingWalls>();
        createWall.CreatWalls();
        createStartAndFinish.CreatingStartMaze(0,0);
        CreateMaze();
    }

    private void CreateMaze()
    {
        do
        {
            neighbors.GetNeighborWeight(positionX, positionY);
            removeWall.RemovingWall();
            allCellsVisited = removingCells.All(x => x.Visited == true);
        } while (!allCellsVisited);
    }

    public int GetHeight()
    {
        return height;
    }
    public int GetWidth()
    {
        return width;
    }
}
