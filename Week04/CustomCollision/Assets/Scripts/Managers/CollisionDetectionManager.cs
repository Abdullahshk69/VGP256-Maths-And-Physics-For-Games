using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionManager : MonoBehaviour
{
    public static CollisionDetectionManager instance;
    public List<Shape> shapes;

    private void Awake()
    {
        instance = this;
        shapes = new List<Shape>();
    }

    // Obtain all the colliders
    public void AddCollider(Shape shape)
    {
        shapes.Add(shape);
        Debug.Log(shapes[0]);
    }


    // Check if they collide with each other

    // If they do, call both of their on collide functions
}
