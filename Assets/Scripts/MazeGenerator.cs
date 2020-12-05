using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject emptyWallPrefab;
    private GameObject[,] maze = new GameObject[height, width];
    private MazeCell[,] mazeCells = new MazeCell[height, width];
    private GameObject nextElement;
    private Vector3 cellPosition;
    private MazeCell cell;
    private const int height = 10;
    private const int width = 10;

    private bool check = false;
       
    private int needed;
    private int positionX;
    private int positionY;
    private bool second;
    private int countVisited =0;
    private int i;

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
        mazeCells[3, 3].Visited = true;
        maze[3, 3].gameObject.SetActive(false);        
        positionX = 3;
        positionY = 3;        
        for (i = 0; i < 15; i++)
        {
            VisitingNextCell();
            Debug.Log($"iteration is {i}");
            check = false;            
            //do
            //{
            //    VisitingNextCell();                
            //}
            //while (check == false);
            //if (check != true)
            //{
            //    i++;
            //}           
        }
    }

    private void VisitingNextCell()
    {
        needed = Random.Range(1, 5);
        //CheckingNeighbors(positionX, positionY, 1, Direction.up);
        //CheckingNeighbors(positionX, positionY, 2, Direction.right);
        //CheckingNeighbors(positionX, positionY, 1, Direction.down);
        //CheckingNeighbors(positionX, positionY, 2, Direction.left);
        if (needed == 1 && positionX + 1 <= width - 1)
        {
            countVisited = 0;
            if (mazeCells[positionX + 1, positionY].Visited == false)
            {
                if (positionY + 1 < height)
                {
                    if (mazeCells[positionX + 1, positionY + 1].Visited == true)
                        countVisited++;
                }

                if (positionY - 1 >= 0)
                {
                    if (mazeCells[positionX + 1, positionY - 1].Visited == true)
                        countVisited++;
                }

                if (positionX + 2 < width)
                {
                    if (mazeCells[positionX + 2, positionY].Visited == true)
                        countVisited++;
                }

                if (mazeCells[positionX, positionY].Visited == true)
                    countVisited++;

                if (countVisited < 2)
                {
                    maze[positionX + 1, positionY].gameObject.SetActive(false);
                    mazeCells[positionX + 1, positionY].Visited = true;
                    positionX += 1;
                    check = true;
                }
            }
        }

        if (needed == 2 && positionY + 1 < height)
        {
            countVisited = 0;
            if (mazeCells[positionX, positionY + 1].Visited == false)
            {

                if (positionY + 2 < height)
                {
                    if (mazeCells[positionX, positionY + 2].Visited == true)
                        countVisited++;
                }

                if (positionX - 1 >= 0)
                {
                    if (mazeCells[positionX - 1, positionY + 1].Visited == true)
                        countVisited++;
                }

                if (positionX + 1 < width)
                {
                    if (mazeCells[positionX + 1, positionY + 1].Visited == true)
                        countVisited++;
                }

                if (mazeCells[positionX, positionY].Visited == true)
                    countVisited++;
                if (countVisited < 2)
                {
                    maze[positionX, positionY + 1].gameObject.SetActive(false);
                    mazeCells[positionX, positionY + 1].Visited = true;
                    positionY += 1;
                    check = true;
                }                
            }
        }

        if (needed == 3 && positionX - 1 >= 0)
        {
            if (mazeCells[positionX - 1, positionY].Visited == false)
            {
                maze[positionX - 1, positionY].gameObject.SetActive(false);
                mazeCells[positionX - 1, positionY].Visited = true;
                positionX -= 1;
                check = true;
            }
        }

        if (needed == 4 && positionY - 1 >= 0)
        {
            if (mazeCells[positionX, positionY - 1].Visited == false)
            {
                maze[positionX, positionY - 1].gameObject.SetActive(false);
                mazeCells[positionX, positionY - 1].Visited = true;
                positionY -= 1;
                check = true;
            }
        }
        i++;
        Debug.Log($"{positionX} and {positionY} and random is {needed}");
    }

    private void CheckingNeighbors( int xPosition, int yPosition, int directionNumber, Direction direction)
    {
        
        switch (direction)
        {
            case Direction.up:                
                second = (yPosition + 1 < height);
                break;
            case Direction.right:
                second = (xPosition + 1 < width);
                break;
            case Direction.down:
                second = (yPosition - 1 >= 0);
                break;
            case Direction.left:
                second = (xPosition - 1 >= 0);
                break;
        } 

        if (needed == directionNumber && second)
        {
            if (mazeCells[xPosition + 1, yPosition].Visited == false)
            {
                if (yPosition + 1 < height)
                {
                    if (mazeCells[xPosition + 1, yPosition + 1].Visited == true)
                        countVisited++;
                }

                if (yPosition - 1 >= 0)
                {
                    if (mazeCells[xPosition + 1, yPosition - 1].Visited == true)
                        countVisited++;
                }

                if (xPosition + 2 < width)
                {
                    if (mazeCells[xPosition + 2, yPosition].Visited == false)
                        countVisited++;
                }

                if (mazeCells[xPosition, yPosition].Visited == false)
                    countVisited++;

                if (countVisited < 2)
                {
                    maze[xPosition + 1, yPosition].gameObject.SetActive(false);
                    mazeCells[xPosition + 1, yPosition].Visited = true;
                    positionX += 1;
                    check = true;
                }
            }
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
