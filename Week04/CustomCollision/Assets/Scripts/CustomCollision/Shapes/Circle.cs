using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
    private Vector2 center;
    [SerializeField] private float radius;

    public Vector2 Center { get { return center; } }
    public float Radius { get { return radius; } }

    private void Start()
    {
        center = transform.position;
        AddCollisionToManager();
    }

    private void Update()
    {
        center = transform.position;
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
        Gizmos.DrawWireSphere(center + offset, radius);
    }

    void OnDrawGizmosSelected()
    {
        DrawShape();
    }

    public override void AddCollisionToManager()
    {
        CollisionDetectionManager.instance.AddCollider(this);
    }
}
