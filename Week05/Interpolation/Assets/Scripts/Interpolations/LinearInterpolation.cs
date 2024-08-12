using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinearInterpolation : MonoBehaviour
{
    [SerializeField] private Slider t;

    [SerializeField] RectTransform start, end;

    [SerializeField] Image interpolatedPoint;

    private void Update()
    {
        interpolatedPoint.transform.position = LinearInterpolate(start.position, end.position, t.value);
    }

    public static Vector2 LinearInterpolate(Vector2 start, Vector2 end, float t)
    {
        Vector2 interpolate = (1 - t) * start + t * end;
        return interpolate;
    }
}
