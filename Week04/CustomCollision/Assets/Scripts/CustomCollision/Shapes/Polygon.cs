using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour, IShape
{
    [SerializeField] private Vector2[] vertices;
    [SerializeField] private bool isTrigger;

    public float AddDistanceToMove()
    {
        throw new System.NotImplementedException();
    }

    public bool CheckCollision<T>(T other) where T : IShape
    {
        throw new System.NotImplementedException();
    }

    public float CheckHowMuchCollisionDistance<T>(T other) where T : IShape
    {
        throw new System.NotImplementedException();
    }

    public void DrawShape()
    {
        Gizmos.color = Color.green;
        for(uint i = 1; i< vertices.Length; i++)
        {
            Gizmos.DrawLine(vertices[i - 1], vertices[i]);
        }
        Gizmos.DrawLine(vertices[0], vertices[^1]);
    }

    private void OnDrawGizmosSelected()
    {
        DrawShape();
    }
}
