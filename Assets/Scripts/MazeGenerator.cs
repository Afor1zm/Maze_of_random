using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject emptyWallPrefab;
    [SerializeField] private List<MazeCell> cells;
    private GameObject[,] maze = new GameObject[height, width];
    private MazeCell[,] mazeCells = new MazeCell[height, width];    
    private Vector3 cellPosition;    
    private const int height = 10;
    private const int width = 10;    
    private int positionX;
    private int positionY;
    private int countVisited = 0;
    private int i;
    int finishPositionX;
    int finishPositionY;
    bool needed;

    void Start()
    {
        CreateMaze();
        CreatingStartMaze(0,0);
        FirstPass();
        Debug.Log($"Finish position is {finishPositionX} and {finishPositionY}");
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
            }
            cellPosition.x = 0;
            cellPosition.y += 1;
        }
    }

    private void CreatingStartMaze(int xPosition, int yPosition)
    {
        mazeCells[xPosition, yPosition].Visited = true;
        mazeCells[xPosition, yPosition].weight = 100;
        maze[xPosition, yPosition].gameObject.SetActive(false);
        positionX = xPosition;
        positionY = yPosition;
    }

    private void FirstPass()
    {
        for (i = 0; i < 60; i++)
        {
            finishPositionX = positionX;
            finishPositionY = positionY;
            Debug.Log($"my position now is {positionX} and {positionY}");
            VisitingNextCell();
            RemoveWall();
        }
        //do
        //{
        //    Debug.Log($"my position now is {positionX} and {positionY}");
        //    VisitingNextCell();
        //    RemoveWall();
        //} while (mazeCells.min == 0);
        
    }
    private void VisitingNextCell()
    {
        GetNeighborWeight(positionX, positionY);                              
    }

    private void RemoveWall()
    {
        if (cells.Count > 0)
        {
            do
            {
                needed = false;
                int minimumWeight = cells.Min(p => p.weight);
                int minimumWeightIndex = cells.FindIndex(p => p.weight == minimumWeight);
                if (cells[minimumWeightIndex].Visited == true)
                {
                    cells.Remove(cells[minimumWeightIndex]);
                }
                else
                {
                    cells[minimumWeightIndex].cellObject.SetActive(false);
                    cells[minimumWeightIndex].Visited = true;
                    Debug.Log($"Now i'm removing wall with coordinate {cells[minimumWeightIndex].PositionX} and {cells[minimumWeightIndex].PositionY}");
                    positionX = cells[minimumWeightIndex].PositionX;
                    positionY = cells[minimumWeightIndex].PositionY;
                    cells.Remove(cells[minimumWeightIndex]);
                    needed = true;
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
        Debug.Log($"Now i'm checking neighbors of {xPosition} and {yPosition}");
        GetWeight(xPosition + 1, yPosition, xPosition + 1 < width && mazeCells[xPosition + 1, yPosition].Visited == false);
        GetWeight(xPosition, yPosition - 1, yPosition - 1 >= 0 && mazeCells[xPosition, yPosition - 1].Visited == false);
        GetWeight(xPosition - 1, yPosition, xPosition - 1 >= 0 && mazeCells[xPosition - 1, yPosition].Visited == false);
        GetWeight(xPosition, yPosition + 1, yPosition + 1 < height && mazeCells[xPosition, yPosition + 1].Visited == false);
    }

    private void GetWeight(int xPosition, int yPosition, bool condition)
    {
        Debug.Log($"Now i'm thinkin about condition {condition}");
        if (condition)
        {
            Debug.Log($"Now i'm thinkin about countVisit {CheckingNeighbors(xPosition, yPosition)}");
            if (CheckingNeighbors(xPosition, yPosition) <=2)
            {
                if (!cells.Contains(mazeCells[xPosition, yPosition]))
                {
                    cells.Add(mazeCells[xPosition, yPosition]);
                }
            }
            else
            {
                mazeCells[xPosition, yPosition].Visited = true;
            }         
        }
    }   
}
