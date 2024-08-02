using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, ICollision
{
    void ICollision.OnCustomCollisionEnter(Shape shape)
    {
        Debug.Log("Success: " +  shape);
    }
}
