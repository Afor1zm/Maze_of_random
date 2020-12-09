using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public bool Visited;
    public bool Canuse;
    public int PositionX;
    public int PositionY;
    public GameObject cellObject;
    public int weight;
}
