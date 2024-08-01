using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : Shape
{
    [SerializeField] private Vector2[] vertices;

    private void Start()
    {
        AddCollisionToManager();
    }

    public override void AddCollisionToManager()
    {
        CollisionDetectionManager.instance.AddCollider(this);
    }

    public override float AddDistanceToMove()
    {
        throw new System.NotImplementedException();
    }

    public override bool CheckCollision<T>(T other)
    {
        throw new System.NotImplementedException();
    }

    public override float CheckHowMuchCollisionDistance<T>(T other)
    {
        throw new System.NotImplementedException();
    }

    public override void DrawShape()
    {
        Gizmos.color = Color.green;
        for(uint i = 1; i< vertices.Length; i++)
        {
            Gizmos.DrawLine(vertices[i - 1] + offset, vertices[i] + offset);
        }
        Gizmos.DrawLine(vertices[0] + offset, vertices[^1] + offset);
    }

    private void OnDrawGizmosSelected()
    {
        DrawShape();
    }
}
