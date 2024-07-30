using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void KeyPickup();
    public static event KeyPickup OnKeyPickup;

    public static void OnPickingUpKey()
    {
        if(OnKeyPickup != null)
        {
            OnKeyPickup();
        }
    }
}
