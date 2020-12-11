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
                mazeGenerator._maze[j, i] = Instantiate(wallPrefab, cellPosition, Quaternion.identity);
                mazeGenerator._mazeCells[j, i] = mazeGenerator._maze[j, i].AddComponent<MazeCell>();
                mazeGenerator._maze[j, i].GetComponent<MazeCell>().cellObject = mazeGenerator._maze[j, i];
                mazeGenerator._mazeCells[j, i].cellObject = mazeGenerator._maze[j, i].GetComponent<MazeCell>().cellObject;
                mazeGenerator._mazeCells[j, i].PositionX = j;
                mazeGenerator._mazeCells[j, i].PositionY = i;
                mazeGenerator._mazeCells[j, i].Visited = false;
                mazeGenerator._mazeCells[j, i].weight = Random.Range(1, 100);
                cellPosition.x += 1;
                mazeGenerator._allCells.Add(mazeGenerator._mazeCells[j, i]);
            }
            cellPosition.x = 0;
            cellPosition.z += 1;
        }
    }
}
