using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RemoveWall : MonoBehaviour, IRemoveWall
{
    private MazeGenerator mazeGenerator;
    bool needed;
    private void Start()
    {
        mazeGenerator = GetComponent<MazeGenerator>();
    }
    public void RemovingWall()
    {
        mazeGenerator = GetComponent<MazeGenerator>();
        if (mazeGenerator.removingCells.Count != 0)
        {
            do
            {
                bool allRemovingCellsVisited = mazeGenerator.removingCells.All(p => p.Visited == true);
                if (allRemovingCellsVisited)
                {
                    mazeGenerator.removingCells.Clear();
                    needed = true;
                }
                else
                {
                    needed = false;
                    int minimumWeight = mazeGenerator.removingCells.Min(p => p.weight);
                    int minimumWeightIndex = mazeGenerator.removingCells.FindIndex(p => p.weight == minimumWeight);
                    if (mazeGenerator.removingCells[minimumWeightIndex].Visited == true)
                    {
                        mazeGenerator.removingCells.Remove(mazeGenerator.removingCells[minimumWeightIndex]);
                    }
                    else
                    {
                        mazeGenerator.removingCells[minimumWeightIndex].cellObject.SetActive(false);
                        mazeGenerator.removingCells[minimumWeightIndex].Visited = true;
                        mazeGenerator._emptyCells.Add(mazeGenerator.removingCells[minimumWeightIndex]);
                        mazeGenerator._positionX = mazeGenerator.removingCells[minimumWeightIndex].PositionX;
                        mazeGenerator._positionY = mazeGenerator.removingCells[minimumWeightIndex].PositionY;
                        mazeGenerator.removingCells.Remove(mazeGenerator.removingCells[minimumWeightIndex]);
                        needed = true;
                    }
                }
            } while (needed == false);
        }
    }
}
