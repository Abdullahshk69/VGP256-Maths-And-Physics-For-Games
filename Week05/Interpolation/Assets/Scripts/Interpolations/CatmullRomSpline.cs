using UnityEngine;
using UnityEngine.UI;

public class CatmullRomSpline : MonoBehaviour
{
    [SerializeField] private RectTransform[] points;

    [SerializeField] private Slider t;
    [SerializeField] private Image interpolate;

    private int curIndex = 0;

    private void Update()
    {
        if (t.value == 1 && curIndex + 1 < points.Length - 1)
        {
            if (Input.GetMouseButtonUp(0))
            {
                t.value = 0;
                curIndex++;
            }
        }
        else if (t.value == 0 && curIndex > 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                t.value = 1;
                curIndex--;
            }
        }

        interpolate.transform.position =
                CubicHermiteCurveInterpolate(points[ClampListPos(curIndex - 1)].position, points[curIndex].position, points[ClampListPos(curIndex + 1)].position, points[ClampListPos(curIndex + 2)].position, t.value);
    }

    public static Vector2 CubicHermiteCurveInterpolate(Vector2 A, Vector2 B, Vector2 C, Vector2 D, float t)
    {
        Vector2 a = 2f * B;
        Vector2 b = C - A;
        Vector2 c = 2f * A - 5f * B + 4f * C - D;
        Vector2 d = -A + 3f * B - 3f * C + D;

        //The cubic polynomial: a + b * t + c * t^2 + d * t^3
        Vector2 pos = 0.5f * (a + (b * t) + (c * t * t) + (d * t * t * t));

        return pos;
    }

    public int ClampListPos(int index)
    {
        if (index < 0)
        {
            index = points.Length - 1;
        }

        if (index > points.Length)
        {
            index = 1;
        }
        else if (index > points.Length - 1)
        {
            index = 0;
        }

        return index;
    }
}
