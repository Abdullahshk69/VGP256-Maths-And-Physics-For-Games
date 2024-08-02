using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : Shape
{
    [SerializeField] Vector2 v1;
    [SerializeField] Vector2 v2;
    private Vector2 center;
    private Vector2 previousCenter;

    public Vector2 V1 { get { return v1; } }
    public Vector2 V2 { get {  return v2; } }

    private void Start()
    {
        center = transform.position;
        previousCenter = transform.position;
        //Vector2 temp1 = v1;
        //v1 = center - (v1 + v2) / 2;
        //v2 = center - (v2 + temp1) / 2;

        v1 = center - v1;
        v2 = center + v2;

        AddCollisionToManager();
    }

    private void Update()
    {
        center = transform.position;
        v1 += center - previousCenter;
        v2 += center - previousCenter;
        previousCenter = center;
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

        // Draw 4 lines

        // { v1.x, v1.y } -> { v2.x, v1.y }
        Gizmos.DrawLine(v1 + offset, new Vector2(v2.x, v1.y) + offset);

        // { v2.x, v1.y } -> { v2.x, v2.y }
        Gizmos.DrawLine(new Vector2(v2.x, v1.y) + offset, v2 + offset);

        // { v2.x, v2.y } -> { v1.x, v2.y }
        Gizmos.DrawLine(v2 + offset, new Vector2(v1.x, v2.y) + offset);

        // { v1.x, v2.y } -> { v1.x, v1.y }
        Gizmos.DrawLine(new Vector2(v1.x, v2.y) + offset, v1 + offset);

    }

    private void OnDrawGizmosSelected()
    {
        DrawShape();
    }

}
