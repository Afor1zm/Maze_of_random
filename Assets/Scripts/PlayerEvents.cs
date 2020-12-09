using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEvents : MonoBehaviour
{
    public Action<Vector3> OnNoise = delegate { Debug.Log($"noised"); };
}
