using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TwoShapes
{
    public Shape s1, s2;
}

public class CustomCollision : MonoBehaviour
{
    TwoShapes shapes = new TwoShapes();

    ICollision[] s1c, s2c; 

    private void Start()
    {
        s1c = shapes.s1.GetComponents<ICollision>();
        s2c = shapes.s2.GetComponents<ICollision>();

        for(int i = 0; i < s1c.Length; i++)
        {
            if(shapes.s1.isTrigger || shapes.s2.isTrigger)
            {
                s1c[i].OnCustomTriggerEnter(shapes.s2);
            }
            else
            {
                s1c[i].OnCustomCollisionEnter(shapes.s2);
            }
        }

        for(int i = 0; i < s2c.Length; i++)
        {
            if(shapes.s1.isTrigger || shapes.s2.isTrigger)
            {
                s2c[i].OnCustomTriggerEnter(shapes.s1);
            }
            else
            {
                s2c[i].OnCustomCollisionEnter(shapes.s1);
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < s1c.Length; i++)
        {
            if (shapes.s1.isTrigger || shapes.s2.isTrigger)
            {
                s1c[i].OnCustomTriggerStay(shapes.s2);
            }
            else
            {
                s1c[i].OnCustomCollisionStay(shapes.s2);
            }
        }

        for (int i = 0; i < s2c.Length; i++)
        {
            if (shapes.s1.isTrigger || shapes.s2.isTrigger)
            {
                s2c[i].OnCustomTriggerStay(shapes.s1);
            }
            else
            {
                s2c[i].OnCustomCollisionStay(shapes.s1);
            }
        }
    }

    public void OnExit()
    {
        for (int i = 0; i < s1c.Length; i++)
        {
            if (shapes.s1.isTrigger || shapes.s2.isTrigger)
            {
                s1c[i].OnCustomTriggerExit(shapes.s2);
            }
            else
            {
                s1c[i].OnCustomCollisionExit(shapes.s2);
            }
        }

        for (int i = 0; i < s2c.Length; i++)
        {
            if (shapes.s1.isTrigger || shapes.s2.isTrigger)
            {
                s2c[i].OnCustomTriggerExit(shapes.s1);
            }
            else
            {
                s2c[i].OnCustomCollisionExit(shapes.s1);
            }
        }
    }
}
