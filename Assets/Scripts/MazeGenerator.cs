using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;    
    [SerializeField] private List<MazeCell> removingCells;
    [SerializeField] private List<MazeCell> allCells;
    [SerializeField] private List<MazeCell> emptyCells;
    private GameObject[,] maze = new GameObject[height, width];
    private MazeCell[,] mazeCells = new MazeCell[height, width];    
    private Vector3 cellPosition;    
    private const int height = 10;
    private const int width = 10;    
    private int positionX;
    private int positionY;
    private int countVisited = 0;    
    bool needed;
    bool allCellsVisited;
    bool allRemovingCellsVisited;    

    void Awake()
    {
        CreateMaze();
        CreatingStartMaze(0,0);
        FirstPass();        
    }
    private void CreateMaze()
    {
        cellPosition = transform.position;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                maze[j, i] = Instantiate(wallPrefab, cellPosition, Quaternion.identity);
                mazeCells[j, i] = maze[j, i].AddComponent<MazeCell>();
                maze[j, i].GetComponent<MazeCell>().cellObject = maze[j, i];
                mazeCells[j, i].cellObject = maze[j, i].GetComponent<MazeCell>().cellObject;
                mazeCells[j, i].PositionX = j;
                mazeCells[j, i].PositionY = i;
                mazeCells[j, i].Visited = false;
                mazeCells[j, i].weight = Random.Range(1, 100);
                cellPosition.x += 1;
                allCells.Add(mazeCells[j, i]);
            }
            cellPosition.x = 0;
            cellPosition.z += 1;
        }
    }

    private void CreatingStartMaze(int xPosition, int yPosition)
    {
        mazeCells[xPosition, yPosition].Visited = true;
        mazeCells[xPosition, yPosition].weight = 100;
        maze[xPosition, yPosition].gameObject.SetActive(false);
        emptyCells.Add(mazeCells[xPosition, yPosition]);

        mazeCells[width-1, height-1].Visited = true;
        mazeCells[width - 1, height - 1].weight = 100;
        maze[width - 1, height - 1].gameObject.SetActive(false);
        emptyCells.Add(mazeCells[width - 1, height - 1]);

        mazeCells[width - 1, height - 2].Visited = true;
        mazeCells[width - 1, height - 2].weight = 100;
        maze[width - 1, height - 2].gameObject.SetActive(false);
        emptyCells.Add(mazeCells[width - 1, height - 2]);

        mazeCells[width - 2, height - 1].Visited = true;
        mazeCells[width - 2, height - 1].weight = 100;
        maze[width - 2, height - 1].gameObject.SetActive(false);
        emptyCells.Add(mazeCells[width - 2, height - 1]);

        positionX = xPosition;
        positionY = yPosition;        
    }

    private void FirstPass()
    {        
        do
        {            
            GetNeighborWeight(positionX, positionY);
            RemoveWall();
            allCellsVisited = allCells.All(x => x.Visited == true);
        } while (!allCellsVisited);

    }

    private void RemoveWall()
    {
        if (removingCells.Count != 0)
        {
            do
            {
                allRemovingCellsVisited = removingCells.All(p => p.Visited == true);
                if (allRemovingCellsVisited)
                {
                    removingCells.Clear();
                    needed = true;
                }
                else
                {
                    needed = false;
                    int minimumWeight = removingCells.Min(p => p.weight);
                    int minimumWeightIndex = removingCells.FindIndex(p => p.weight == minimumWeight);
                    if (removingCells[minimumWeightIndex].Visited == true)
                    {
                        removingCells.Remove(removingCells[minimumWeightIndex]);
                    }
                    else
                    {
                        removingCells[minimumWeightIndex].cellObject.SetActive(false);
                        removingCells[minimumWeightIndex].Visited = true;
                        emptyCells.Add(removingCells[minimumWeightIndex]);
                        positionX = removingCells[minimumWeightIndex].PositionX;
                        positionY = removingCells[minimumWeightIndex].PositionY;
                        removingCells.Remove(removingCells[minimumWeightIndex]);
                        needed = true;
                    }
                }                
            } while (needed == false);
        }
    }

    private int CheckingNeighbors(int xPosition, int yPosition)
    {
        countVisited = 0;              
        GetVisitedNeighbor(xPosition + 1, yPosition, xPosition + 1 < width);
        GetVisitedNeighbor(xPosition, yPosition - 1, yPosition - 1 >= 0);
        GetVisitedNeighbor(xPosition - 1, yPosition, xPosition - 1 >= 0);
        GetVisitedNeighbor(xPosition, yPosition + 1, yPosition + 1 < height);
        return countVisited;        
    }

    private void GetVisitedNeighbor(int xPosition, int yPosition, bool condition)
    {
        if (condition)
        {
            if (mazeCells[xPosition, yPosition].Visited == true)
                 countVisited++;
        }
    }

    private void GetNeighborWeight(int xPosition, int yPosition)
    {
        GetWeight(xPosition + 1, yPosition, xPosition + 1 < width && mazeCells[xPosition + 1, yPosition].Visited == false);
        GetWeight(xPosition, yPosition - 1, yPosition - 1 >= 0 && mazeCells[xPosition, yPosition - 1].Visited == false);
        GetWeight(xPosition - 1, yPosition, xPosition - 1 >= 0 && mazeCells[xPosition - 1, yPosition].Visited == false);
        GetWeight(xPosition, yPosition + 1, yPosition + 1 < height && mazeCells[xPosition, yPosition + 1].Visited == false);
    }

    private void GetWeight(int xPosition, int yPosition, bool condition)
    {
       if (condition)
        {
            if (CheckingNeighbors(xPosition, yPosition) <=2)
            {
                if (!removingCells.Contains(mazeCells[xPosition, yPosition]))
                {
                    removingCells.Add(mazeCells[xPosition, yPosition]);
                }
            }
            else
            {
                mazeCells[xPosition, yPosition].Visited = true;
            }         
        }
    }

    public List<MazeCell> GetEmptyList()
    {
        return emptyCells;
    }
}
