using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rectangle : Shape
{
    [SerializeField] Vector2 v1;
    [SerializeField] Vector2 v2;
    private Vector2 center;
    private Vector2 previousCenter;

    [SerializeField] private bool useSprite;

    public Vector2 V1 { get { return v1; } }
    public Vector2 V2 { get {  return v2; } }

    public float Width { get { return Mathf.Abs(v2.x - v1.x); } }
    public float Height { get { return Mathf.Abs(v2.y - v1.y); } }

    private void Start()
    {
        center = transform.position;
        previousCenter = transform.position;

        if (TryGetComponent(out SpriteRenderer sprite) && useSprite)
        {
            Debug.Log("Bot left: " + sprite.sprite.bounds.min
                + "\nTop Right: " + sprite.sprite.bounds.max);

            v1 = sprite.sprite.bounds.min * (Vector2)transform.localScale;
            v2 = sprite.sprite.bounds.max * (Vector2)transform.localScale;

            v1 = center + v1;
            v2 = center + v2;
        }

        else
        {
            float halfWidth = Width / 2;
            float halfHeight = Height / 2;

            v1.x = center.x - halfWidth;
            v1.y = center.y - halfHeight;

            v2.x = center.x + halfWidth;
            v2.y = center.y + halfHeight;
        }
       
        //Vector2 temp1 = v1;
        //v1 = center - (v1 + v2) / 2;
        //v2 = center + ((v2 + temp1) / 2);

        //Debug.Log("Object: " + name + "Center: " + center);


        

        AddCollisionToManager();
    }

    private void Update()
    {
        center = transform.position;
        v1 += center - previousCenter;
        v2 += center - previousCenter;
        previousCenter = center;
    }

    public Vector2 GetCenter()
    {
        return ((v1 + v2) / 2) + offset;
    }

    public override void AddCollisionToManager()
    {
        CollisionDetectionManager.instance.AddCollider(this);
    }

    public override void AddDistanceToMove(Vector2 distance)
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
