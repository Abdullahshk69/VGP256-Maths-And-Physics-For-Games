using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<string, int> keyValue;
    Dictionary<string, int> doorValue;

    
    private void Start()
    {
        Instance = this;
        const int charisma = 1 << 0;
        const int fly = 1 << 1;
        const int intelligence = 1 << 2;
        const int invisible = 1 << 3;
        const int magic = 1 << 4;
        const int golden = charisma + fly + intelligence + invisible + magic;
        keyValue = new Dictionary<string, int>
        {
            { "Charisma", charisma },
            { "Fly", fly },
            { "Intelligence", intelligence },
            { "Invisible", invisible },
            { "Magic", magic },
            { "Golden", golden }
        };

        doorValue = new Dictionary<string, int>
        {
            { "Charisma", charisma },
            { "Fly", fly },
            { "Intelligence", intelligence },
            { "Invisible", invisible },
            { "Magic", magic },
            { "Brown", fly + intelligence }
        };
    }

    #region Key
    public int GetKey(string keyTag)
    {
        if (keyValue.TryGetValue(keyTag, out int value))
        {
            return value;
        }
        return 0;
    }
    #endregion

    #region Door
    public bool CheckIfDoorCanOpen(string doorTag)
    {
        if(doorValue.TryGetValue(doorTag, out int value))
        {
            if((PlayerManager.Instance.attributes & value) == value)
            {
                PlayerManager.Instance.attributes &= ~value;
                return true;
            }
        }
        return false;
    }

    #endregion
}
