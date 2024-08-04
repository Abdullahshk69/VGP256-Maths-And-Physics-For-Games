using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    public static DoorManager instance;

    Dictionary<string, int> doors;

    readonly int redDoor = 1 << 0;
    readonly int greenDoor = 1 << 1;
    readonly int blueDoor = 1 << 2;

    private void Start()
    {
        instance = this;
        doors = new Dictionary<string, int>
        {
            { "Red", redDoor },
            { "Green", greenDoor },
            { "Blue", blueDoor },
        };
    }

    public int GetDoorKey(string doorKey)
    {
        if(doors.TryGetValue(doorKey, out int key))
        {
            return key;
        }
        return 0;
    }
}
