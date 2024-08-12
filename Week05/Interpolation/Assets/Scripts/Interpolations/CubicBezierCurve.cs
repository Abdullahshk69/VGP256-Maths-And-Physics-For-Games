using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubicBezierCurve : MonoBehaviour
{
    [SerializeField] private Slider t;
    [SerializeField] private RectTransform A, B, C, D;

    [SerializeField] private Image interpolate;

    private void Update()
    {
        interpolate.transform.position = CubicInterpolation(A.position, B.position, C.position, D.position, t.value);
    }

    public static Vector2 CubicInterpolation(Vector2 A, Vector2 B, Vector2 C, Vector2 D, float t)
    {
        Vector2 Q =QuadraticBezierCurve.QuadraticInterpolation(A, B, C, t);
        Vector2 R =QuadraticBezierCurve.QuadraticInterpolation(B, C, D, t);
        Vector2 interpolate = LinearInterpolation.LinearInterpolate(Q, R, t);
        return interpolate;
    }
}
