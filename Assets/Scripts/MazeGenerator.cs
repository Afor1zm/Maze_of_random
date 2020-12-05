using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject emptyWallPrefab;
    private GameObject[,] maze = new GameObject[height, width];
    private MazeCell[,] mazeCells = new MazeCell[height, width];    
    private Vector3 cellPosition;    
    private const int height = 10;
    private const int width = 10;
    private int needed;
    private int positionX;
    private int positionY;
    private bool isCellExist;
    private int countVisited =0;
    private int i;
    int nextStepCellX;
    int nextStepCellY;

    private enum Direction
    {
        up,
        right,
        down,
        left
    }

    void Start()
    {
        CreateMaze();
        FirstPass();
    }

    private void FirstPass()
    {
        mazeCells[0, 0].Visited = true;
        maze[0, 0].gameObject.SetActive(false);        
        positionX = 0;
        positionY = 0;        
        for (i = 0; i < 25; i++)
        {
            VisitingNextCell();                       
        }
    }

    private void VisitingNextCell()
    {        
        needed = Random.Range(1, 5);        
        CheckingNeighbors(positionX, positionY, 1, Direction.right);
        CheckingNeighbors(positionX, positionY, 2, Direction.up);
        CheckingNeighbors(positionX, positionY, 3, Direction.down);
        CheckingNeighbors(positionX, positionY, 4, Direction.left);               
    }

    private void CheckingNeighbors(int xPosition, int yPosition, int directionNumber, Direction direction)
    {
        countVisited = 0;
        switch (direction)
        {
            case Direction.up:                
                isCellExist = (yPosition + 1 < height);
                nextStepCellX = xPosition;
                nextStepCellY = yPosition + 1;
                break;
            case Direction.right:
                isCellExist = (xPosition + 1 < width);
                nextStepCellX = xPosition + 1;
                nextStepCellY = yPosition;
                             
                break;
            case Direction.down:
                isCellExist = (yPosition - 1 >= 0);
                nextStepCellX = xPosition;
                nextStepCellY = yPosition - 1;

                break;
            case Direction.left:
                isCellExist = (xPosition - 1 >= 0);
                nextStepCellX = xPosition - 1;
                nextStepCellY = yPosition;
                break;
        }
        
        if (needed == directionNumber && isCellExist)
        {            
            if (mazeCells[nextStepCellX, nextStepCellY].Visited == false)
            {
                GetVisitedNeighbor(nextStepCellX + 1, nextStepCellY, nextStepCellX + 1 < width);
                GetVisitedNeighbor(nextStepCellX, nextStepCellY -1, nextStepCellY - 1 >= 0);                
                GetVisitedNeighbor(nextStepCellX - 1, nextStepCellY, nextStepCellX - 1 >= 0);
                GetVisitedNeighbor(nextStepCellX, nextStepCellY + 1, nextStepCellY + 1 < height);
                if (countVisited < 2)
                {
                    maze[nextStepCellX, nextStepCellY].gameObject.SetActive(false);
                    mazeCells[nextStepCellX, nextStepCellY].Visited = true;
                    positionX = nextStepCellX;
                    positionY = nextStepCellY;                    
                }
            }
        }
    }

    private void GetVisitedNeighbor(int xPosition, int yPosition, bool condition)
    {
        if (condition)
        {
            if (mazeCells[xPosition, yPosition].Visited == true)
                countVisited++;
        }
    }

    private void CreateMaze()
    {
        cellPosition = transform.position;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                maze[j,i] = Instantiate(wallPrefab, cellPosition, Quaternion.identity);                
                mazeCells[j, i] = maze[j, i].AddComponent<MazeCell>();
                maze[j, i].GetComponent<MazeCell>().cellObject = maze[j,i];
                mazeCells[j, i].cellObject = maze[j, i].GetComponent<MazeCell>().cellObject;
                mazeCells[j, i].PositionX = j;
                mazeCells[j, i].PositionY = i;
                mazeCells[j, i].Visited = false;                
                cellPosition.x += 1;
            }
            cellPosition.x = 0;
            cellPosition.y += 1;
        }
    }
}
