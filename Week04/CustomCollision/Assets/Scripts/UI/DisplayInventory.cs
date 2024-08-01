using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    [SerializeField] Image redKey;
    [SerializeField] Image greenKey;
    [SerializeField] Image blueKey;

    private void Start()
    {
        EventManager.OnKeyPickup += UpdateAllKeyDisplays;

        UpdateAllKeyDisplays();
    }

    private void Update()
    {
        UpdateAllKeyDisplays();
    }

    private void UpdateAllKeyDisplays()
    {
        UpdateKeyDisplay(ref redKey, "Red");
        UpdateKeyDisplay(ref greenKey, "Green");
        UpdateKeyDisplay(ref blueKey, "Blue");
    }    

    private void UpdateKeyDisplay(ref Image keyImage, string keyTag)
    {
        if ((GameManager.Instance.KeyInventory & KeyManager.instance.GetKey(keyTag)) != 0)
        {
            keyImage.CrossFadeAlpha(1.0f, 0.1f, true);
        }

        else
        {
            keyImage.CrossFadeAlpha(0.1f, 0.1f, true);
        }
    }
}
