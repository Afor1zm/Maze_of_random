using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    public List<MazeCell> _removingCells = new List<MazeCell>();
    public MazeCell[,] _mazeCells = new MazeCell[_height, _width];
    public List<MazeCell> _emptyCells = new List<MazeCell>();
    public int _positionX;
    public int _positionY;
    public GameObject[,] _maze = new GameObject[_height, _width];
    public const int _height = 10;
    public const int _width = 10;      
    public List<MazeCell> _allCells = new List<MazeCell>();    
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
            neighbors.GetNeighborWeight(_positionX, _positionY);
            removeWall.RemovingWall();
            allCellsVisited = _removingCells.All(x => x.Visited == true);
        } while (!allCellsVisited);
    }

    public int GetHeight()
    {
        return _height;
    }

    public int GetWidth()
    {
        return _width;
    }
}
