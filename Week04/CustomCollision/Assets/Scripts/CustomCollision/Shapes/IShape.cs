using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShape
{
    public bool CheckCollision<T>(T other) where T : IShape;
    public void DrawShape();
    public float AddDistanceToMove();
    public float CheckHowMuchCollisionDistance<T>(T other) where T : IShape;
    public void AddCollisionToManager();
}
