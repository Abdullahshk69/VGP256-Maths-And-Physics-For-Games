using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Key
    public int KeyInventory {  get; set; }

    // maybe use game manager to detect collision

    private void Awake()
    {
        Instance = this;
        KeyInventory = 0;    
    }

    public void ObtainKey(string keyTag)
    {
        KeyInventory |= KeyManager.instance.GetKey(keyTag);
    }
}
