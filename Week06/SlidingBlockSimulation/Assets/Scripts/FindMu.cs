using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMu : MonoBehaviour
{
    public static FindMu instance;
    [SerializeField]
    Dictionary<string, float> muCoefficients;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        muCoefficients = new Dictionary<string, float>()
        {
            { "Wood+Wood", 0.5f },
            { "Wood+Rubber", 0.75f },
            { "Rubber+Wood", 0.75f },
            { "Concrete+Rubber", 0.75f },
            { "Rubber+Concrete", 0.75f }
        };
    }

    public float GetMu(string objects)
    {
        if(muCoefficients.TryGetValue(objects, out float result))
        {
            return result;
        }
        return 0.0f;
    }
}
