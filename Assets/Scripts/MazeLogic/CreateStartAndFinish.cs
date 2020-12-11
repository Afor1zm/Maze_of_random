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
        mazeGenerator._mazeCells[xPosition, yPosition].Visited = true;
        mazeGenerator._mazeCells[xPosition, yPosition].weight = 100;
        mazeGenerator._maze[xPosition, yPosition].gameObject.SetActive(false);
        mazeGenerator._emptyCells.Add(mazeGenerator._mazeCells[xPosition, yPosition]);

        mazeGenerator._mazeCells[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1].Visited = true;
        mazeGenerator._mazeCells[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1].weight = 100;
        mazeGenerator._maze[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1].gameObject.SetActive(false);
        mazeGenerator._emptyCells.Add(mazeGenerator._mazeCells[mazeGenerator.GetWidth() - 1, mazeGenerator.GetHeight() - 1]);

        mazeGenerator._positionX = xPosition;
        mazeGenerator._positionY = yPosition;
    }
}
