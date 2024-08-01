using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : Shape
{
    private Vector2 center;
    [SerializeField] private float radius;
    

    private void Start()
    {
        center = GetComponent<Transform>().position;
        AddCollisionToManager();
    }

    private void Update()
    {
        
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
