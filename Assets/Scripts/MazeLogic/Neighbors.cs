using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighbors : MonoBehaviour, INeighbors
{
    private MazeGenerator mazeGenerator;
    private const int height = 10;
    private const int width = 10;
    private int countVisited = 0;

    private void Start()
    {
        mazeGenerator = GetComponent<MazeGenerator>();
    }
    public int CheckingNeighbors(int xPosition, int yPosition)
    {
        countVisited = 0;
        GetVisitedNeighbor(xPosition + 1, yPosition, xPosition + 1 < width);
        GetVisitedNeighbor(xPosition, yPosition - 1, yPosition - 1 >= 0);
        GetVisitedNeighbor(xPosition - 1, yPosition, xPosition - 1 >= 0);
        GetVisitedNeighbor(xPosition, yPosition + 1, yPosition + 1 < height);
        return countVisited;
    }

    public void GetVisitedNeighbor(int xPosition, int yPosition, bool condition)
    {
        mazeGenerator = GetComponent<MazeGenerator>();
        if (condition)
        {
            if (mazeGenerator._mazeCells[xPosition, yPosition].Visited == true)
                countVisited++;
        }
    }

    public void GetNeighborWeight(int xPosition, int yPosition)
    {
        GetWeight(xPosition + 1, yPosition, xPosition + 1 < width);
        GetWeight(xPosition, yPosition - 1, yPosition - 1 >= 0);
        GetWeight(xPosition - 1, yPosition, xPosition - 1 >= 0);
        GetWeight(xPosition, yPosition + 1, yPosition + 1 < height);
    }

    public void GetWeight(int xPosition, int yPosition, bool condition)
    {
        mazeGenerator = GetComponent<MazeGenerator>();
        if (condition)
        {
            if (CheckingNeighbors(xPosition, yPosition) <= 2)
            {
                if (!mazeGenerator.removingCells.Contains(mazeGenerator._mazeCells[xPosition, yPosition]))
                {
                    mazeGenerator.removingCells.Add(mazeGenerator._mazeCells[xPosition, yPosition]);
                }
            }
            else
            {
                mazeGenerator._mazeCells[xPosition, yPosition].Visited = true;
            }
        }
    }
}
