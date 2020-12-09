using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateStartAndFinish : MonoBehaviour, ICreatingDestination
{
    private MazeGenerator mazeGenerator;
    private void Start()
    {
        mazeGenerator = GetComponent<MazeGenerator>();
    }
    public void CreatingStartMaze(int xPosition, int yPosition)
    {
        mazeGenerator = GetComponent<MazeGenerator>();
        mazeGenerator.mazeCells[xPosition, yPosition].Visited = true;
        mazeGenerator.mazeCells[xPosition, yPosition].weight = 100;
        mazeGenerator.maze[xPosition, yPosition].gameObject.SetActive(false);
        mazeGenerator.emptyCells.Add(mazeGenerator.mazeCells[xPosition, yPosition]);

        mazeGenerator.mazeCells[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1].Visited = true;
        mazeGenerator.mazeCells[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1].weight = 100;
        mazeGenerator.maze[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1].gameObject.SetActive(false);
        mazeGenerator.emptyCells.Add(mazeGenerator.mazeCells[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1]);

        mazeGenerator.positionX = xPosition;
        mazeGenerator.positionY = yPosition;
    }
}
