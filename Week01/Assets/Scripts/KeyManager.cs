using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;


    public Text attributeDisplay;
    static public int attributes = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MAGIC_KEY")
        {
            attributes |= MAGIC;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "INTELLIGENCE_KEY")
        {
            attributes |= INTELLIGENCE;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "CHARISMA_KEY")
        {
            attributes |= CHARISMA;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "FLY_KEY")
        {
            attributes |= FLY;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "INVISIBLE_KEY")
        {
            attributes |= INVISIBLE;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "GOLDEN_KEY")
        {
            attributes |= MAGIC;
            attributes |= INVISIBLE;
            attributes |= FLY;
            attributes |= CHARISMA;
            attributes |= INTELLIGENCE;
            Destroy(other.gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0, -50, 0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
}
