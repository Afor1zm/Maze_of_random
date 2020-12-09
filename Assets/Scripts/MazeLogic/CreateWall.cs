using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWall : MonoBehaviour, ICreatingWalls
{
    private MazeGenerator mazeGenerator;
    [SerializeField] private GameObject wallPrefab;
    public void CreatWalls()
    {
        mazeGenerator = GetComponent<MazeGenerator>();
        Vector3 cellPosition = transform.position;
        for (int i = 0; i < mazeGenerator.GetHeight(); i++)
        {
            for (int j = 0; j < mazeGenerator.GetWidth(); j++)
            {
                mazeGenerator.maze[j, i] = Instantiate(wallPrefab, cellPosition, Quaternion.identity);
                mazeGenerator.mazeCells[j, i] = mazeGenerator.maze[j, i].AddComponent<MazeCell>();
                mazeGenerator.maze[j, i].GetComponent<MazeCell>().cellObject = mazeGenerator.maze[j, i];
                mazeGenerator.mazeCells[j, i].cellObject = mazeGenerator.maze[j, i].GetComponent<MazeCell>().cellObject;
                mazeGenerator.mazeCells[j, i].PositionX = j;
                mazeGenerator.mazeCells[j, i].PositionY = i;
                mazeGenerator.mazeCells[j, i].Visited = false;
                mazeGenerator.mazeCells[j, i].weight = Random.Range(1, 100);
                cellPosition.x += 1;
                mazeGenerator.allCells.Add(mazeGenerator.mazeCells[j, i]);
            }
            cellPosition.x = 0;
            cellPosition.z += 1;
        }
    }
}
