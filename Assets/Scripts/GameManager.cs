﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public InputController InputController { get; private set; }
    void Awake()
    {
        Instance = this;
        InputController = GetComponentInChildren<InputController>();
    }

    void Update()
    {
        
    }
}
