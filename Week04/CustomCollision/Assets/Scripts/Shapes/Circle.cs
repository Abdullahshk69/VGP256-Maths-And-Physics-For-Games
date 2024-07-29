using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour, IShape
{
    private Vector2 center;
    [SerializeField] private float radius;

    private void Start()
    {
        center = GetComponent<Transform>().position;

    }

    private void Update()
    {
        
    }

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
        Gizmos.DrawWireSphere(center, radius);
    }

    void OnDrawGizmosSelected()
    {
        DrawShape();
    }
}
