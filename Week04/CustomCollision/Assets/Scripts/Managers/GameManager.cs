using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Key
    public int KeyInventory {  get; set; }

    public event EventHandler gainKeyEvent;

    // maybe use game manager to detect collision

    private void Awake()
    {
        Instance = this;
        KeyInventory = 0;    
    }

    public void ObtainKey()
    {
        EventManager.OnPickingUpKey();
    }
}
