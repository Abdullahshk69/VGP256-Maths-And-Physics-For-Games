using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetectionManager : MonoBehaviour
{
    public static CollisionDetectionManager instance;
    public List<Shape> shapes;
    CollisionChecker checker;

    bool removedCollider = false;

    int i, j;

    private void Awake()
    {
        instance = this;
        shapes = new List<Shape>();
        checker = new CollisionChecker();
    }

    // Obtain all the colliders
    public void AddCollider(Shape shape)
    {
        shapes.Add(shape);
    }

    public void RemoveCollider(Shape shape)
    {
        shapes.Remove(shape);
        removedCollider = true;
        //Debug.Log("i = " + i);
        i = Mathf.Clamp(i - 1, 0, shapes.Count);
        //Debug.Log("i = " + i);
        j = Mathf.Clamp(j - 1, 0, shapes.Count);
    }

    private void Update()
    {
        // Check after every other frame

        // Check if they collide with each other

        for (i = 0; i < shapes.Count; i++)
        {
            //if (removedCollider)
            //{
            //    removedCollider = false;
            //    break;
            //}

            for (j = i+1; j < shapes.Count; j++)
            {
                //if (removedCollider)
                //{
                //    break;
                //}

                bool isColliding = checker.IsColliding(shapes[i], shapes[j]);
                Debug.Log(isColliding);

                if (isColliding)
                {
                    ICollision collision;
                    if (shapes[i].TryGetComponent(out collision))
                    {
                        collision.OnCustomCollisionEnter(shapes[j]);
                    }
                    if (shapes[j].TryGetComponent(out collision))
                    {
                        collision.OnCustomCollisionEnter(shapes[i]);
                    }
                }
            }
            
        }
    }

    // If they do, call both of their on collide functions
}
