using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UINoiseLevel : MonoBehaviour
{
    private Text label;
    [SerializeField] private PlayerNoise playerNoise;

    private void Start()
    {
        label = GetComponent<Text>();
    }

    private void Update()
    {
        Math.Round(playerNoise.GetPlayerNoise(), 2);
        label.text = ($"{ Math.Round(playerNoise.GetPlayerNoise(), 2)}");
    }
}
