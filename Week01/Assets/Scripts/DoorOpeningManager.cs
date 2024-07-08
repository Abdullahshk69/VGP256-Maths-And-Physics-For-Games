using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpeningManager : MonoBehaviour
{
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    private BoxCollider passibleDoor = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MAGIC_DOOR" && (KeyManager.attributes & MAGIC) != 0)
        {
            KeyManager.attributes &= ~MAGIC;
            passibleDoor = other.GetComponent<BoxCollider>();
            passibleDoor.isTrigger = true;
        }
        else if (other.gameObject.tag == "INTELLIGENCE_DOOR" && KeyManager.attributes == INTELLIGENCE)
        {
            KeyManager.attributes &= ~INTELLIGENCE;
            passibleDoor = other.GetComponent<BoxCollider>();
            passibleDoor.isTrigger = true;
        }
        else if (other.gameObject.tag == "CHARISMA_DOOR" && KeyManager.attributes == CHARISMA)
        {
            KeyManager.attributes &= ~CHARISMA;
            passibleDoor = other.GetComponent<BoxCollider>();
            passibleDoor.isTrigger = true;
        }
        else if (other.gameObject.tag == "FLY_DOOR" && KeyManager.attributes == FLY)
        {
            KeyManager.attributes &= ~FLY;
            passibleDoor = other.GetComponent<BoxCollider>();
            passibleDoor.isTrigger = true;
        }
        else if (other.gameObject.tag == "INVISIBLE_DOOR" && KeyManager.attributes == INVISIBLE)
        {
            KeyManager.attributes &= ~INVISIBLE;
            passibleDoor = other.GetComponent<BoxCollider>();
            passibleDoor.isTrigger = true;
        }
        else if (other.gameObject.tag == "FLY_&_CHARISMA_DOOR" && (KeyManager.attributes & FLY) != 0 && (KeyManager.attributes & CHARISMA) != 0)
        {
            KeyManager.attributes &= ~CHARISMA;
            KeyManager.attributes &= ~FLY;
            passibleDoor = other.GetComponent<BoxCollider>();
            passibleDoor.isTrigger = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (passibleDoor == null)
            return;
        passibleDoor.isTrigger = false;
        passibleDoor = null;
    }
}
