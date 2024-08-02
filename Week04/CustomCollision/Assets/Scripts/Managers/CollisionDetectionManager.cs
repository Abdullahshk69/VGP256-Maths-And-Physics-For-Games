using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionManager : MonoBehaviour
{
    public static CollisionDetectionManager instance;
    public List<Shape> shapes;
    CollisionChecker checker;

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


    private void Update()
    {
        // Check if they collide with each other

        for (int i = 0; i < shapes.Count; i++)
        {
            for(int j = i+1; j < shapes.Count; j++)
            {
                bool isColliding = checker.IsColliding(shapes[i], shapes[j]);
                Debug.Log(isColliding);

                if (isColliding)
                {
                    ICollision collision;
                    if (shapes[i].TryGetComponent(out collision))
                    {
                        collision.OnCustomCollisionEnter(shapes[j]);
                    }
                }
            }
            
        }
    }

    // If they do, call both of their on collide functions
}
