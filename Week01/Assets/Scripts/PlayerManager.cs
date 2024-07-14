using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    [SerializeField] private Text attributeDisplay;
    public int attributes = 0;

    private void Start()
    {
        Instance = this;
    }

    private void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0, -50, 0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Key")
        {
            attributes |= GameManager.Instance.GetKey(other.GetComponent<KeyAttacher>().key.keyTag);
        }
        else if(other.tag == "Door")
        {
            if(GameManager.Instance.CheckIfDoorCanOpen(other.GetComponent<DoorAttacher>().door.doorTag))
            {
                other.GetComponent<Collider>().isTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Door")
        {
            other.GetComponent<Collider>().isTrigger = false;
        }
    }
}
