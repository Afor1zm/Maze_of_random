using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEvents : MonoBehaviour
{
    public Action<Vector3> OnNoise = delegate { Debug.Log($"noised"); };
    public Action OnGameOver = delegate { Debug.Log($"died"); };
    public Action OnWin = delegate { Debug.Log($"Win"); };
    public Action<Vector3> OnDetected = delegate { Debug.Log($"Spoted in FOW"); };
    public Action OnSectorChecked = delegate { Debug.Log($"Sector checked and clear"); };
}
