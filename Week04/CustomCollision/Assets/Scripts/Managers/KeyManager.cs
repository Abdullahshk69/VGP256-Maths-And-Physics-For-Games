using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instance;
    Dictionary<string, int> keyValues;

    readonly int redKey = 1 << 0;
    readonly int greenKey = 1 << 1;
    readonly int blueKey = 1 << 2;

    private void Awake()
    {
        instance = this;
        keyValues = new Dictionary<string, int>
        {
            { "Red", redKey },
            { "Green", greenKey },
            { "Blue", blueKey },
        };
    }
    
    public void UseKey(string key)
    {
        if(keyValues.TryGetValue(key, out int value))
        {
            GameManager.Instance.KeyInventory &= ~value;
        }
    }

    public int GetKey(string key)
    {
        if (keyValues.TryGetValue(key, out int value))
        {
            return value;
        }
        return 0;
    }    
}
