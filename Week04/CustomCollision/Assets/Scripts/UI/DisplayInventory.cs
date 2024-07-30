using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI redKey;
    [SerializeField] TextMeshProUGUI greenKey;
    [SerializeField] TextMeshProUGUI blueKey;

    private void Start()
    {
        redKey.color = Color.red;
        greenKey.color = Color.green;
        blueKey.color = Color.blue;
        EventManager.OnKeyPickup += UpdateAllKeyDisplays;
    }

    private void UpdateAllKeyDisplays()
    {
        UpdateKeyDisplay(ref redKey, "Red");
        UpdateKeyDisplay(ref greenKey, "Green");
        UpdateKeyDisplay(ref blueKey, "Blue");
    }    

    private void UpdateKeyDisplay(ref TextMeshProUGUI keyTextDisplay, string keyTag)
    {
        if ((GameManager.Instance.KeyInventory & KeyManager.instance.GetKey(keyTag)) != 0)
        {
            keyTextDisplay.CrossFadeAlpha(255, 0.1f, false);
        }

        else
        {
            keyTextDisplay.CrossFadeAlpha(100, 0.1f, false);
        }
    }
}
