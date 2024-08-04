using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shape : MonoBehaviour
{
    public bool isTrigger;
    public Vector2 offset;
    abstract public bool CheckCollision<T>(T other) where T : Shape;

    abstract public void DrawShape();
    abstract public void AddDistanceToMove(Vector2 distance);
    abstract public float CheckHowMuchCollisionDistance<T>(T other) where T : Shape;
    abstract public void AddCollisionToManager();
}
