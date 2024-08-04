using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionChecker
{
    public bool IsColliding(Shape s1, Shape s2)
    {
        // Both colliders are circle
        if (s1 is Circle && s2 is Circle)
        {
            return IsColliding((Circle)s1, (Circle)s2);
        }

        // If both are rectangles
        else if (s1 is Rectangle && s2 is Rectangle)
        {
            return IsColliding((Rectangle)s1, (Rectangle)s2);
        }

        else if (s1 is Circle && s2 is Rectangle)
        {
            return IsColliding((Circle)s1, (Rectangle)s2);
        }

        else if (s1 is Rectangle && s2 is Circle)
        {
            return IsColliding((Rectangle)s1, (Circle)s2);
        }

        return false;
    }

    public bool IsColliding(Circle c1, Circle c2)
    {
        bool isColliding;

        Vector2 distanceCenter = new Vector2
                                ((c2.Center.x + c2.offset.x) - (c1.Center.x + c1.offset.x),
                                 (c2.Center.y + c2.offset.y) - (c1.Center.y + c1.offset.y));

        float distanceSquared = MathF.Pow((distanceCenter.x), 2) + MathF.Pow((distanceCenter.y), 2);
        float radiusSumSquared = MathF.Pow(c1.Radius + c2.Radius, 2);

        isColliding = (distanceSquared <= radiusSumSquared);
        return isColliding;
    }

    public bool IsColliding(Rectangle r1, Rectangle r2)
    {
        bool isColliding;

        //B1.x.max > B2.x.min
        //B1.x.min < B2.x.max
        //B1.y.max > B2.y.min
        //B1.y.min < B2.y.max

        isColliding =
            ((r1.V2.x + r1.offset.x) > (r2.V1.x + r2.offset.x) &&
            (r1.V1.x + r1.offset.x) < (r2.V2.x + r2.offset.x)) &&
            ((r1.V2.y + r1.offset.y) > (r2.V1.y + r2.offset.y) &&
            (r1.V1.y + r1.offset.y) < (r2.V2.y + r2.offset.y));

        return isColliding;
    }

    public bool IsColliding(Rectangle r, Circle c)
    {
        bool isColliding = false;

        Vector2 recCenter = r.GetCenter();
        float dx = Mathf.Abs(c.Center.x + c.offset.x - recCenter.x+r.offset.x);
        float dy = Mathf.Abs(c.Center.y + c.offset.y - recCenter.y+r.offset.y);

        
        if (dx > (r.Width / 2) + c.Radius || dy > (r.Height / 2) + c.Radius)
        {
            return false;
        }

        if (dx <= (r.Width / 2) || dy <= r.Height / 2)
        {
            return true;
        }

        float cornerDistanceSq = (dx - r.Width / 2) * (dx - r.Width / 2) +
                                    (dy - r.Height / 2) * (dy - r.Height / 2);

        isColliding = (cornerDistanceSq <= (c.Radius * c.Radius));

        return isColliding;
    }

    public bool IsColliding(Circle c, Rectangle r)
    {
        return IsColliding(r, c);
    }


}
