using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polygon : MonoBehaviour, IShape
{
    [SerializeField] private Vector3[] vertices;

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
        Gizmos.color = Color.yellow;
        for(uint i = 1; i< vertices.Length; i++)
        {
            Gizmos.DrawLine(vertices[i - 1], vertices[i]);
        }
        Gizmos.DrawLine(vertices[0], vertices[vertices.Length - 1]);
    }

    private void OnDrawGizmosSelected()
    {
        DrawShape();
    }
}
