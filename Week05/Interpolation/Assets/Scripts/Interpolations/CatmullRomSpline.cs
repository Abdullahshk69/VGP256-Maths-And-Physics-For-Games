using System.Collections;
using System.Collections.Generic;
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
            if(Input.GetMouseButtonUp(0))
            {
                t.value = 0;
                curIndex++;
            }
        }
        else if(t.value == 0 && curIndex > 0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                t.value = 1;
                curIndex--;
            }
        }

        if(curIndex == 0)
        {
            interpolate.transform.position =
                QuadraticBezierCurve.QuadraticInterpolation(points[curIndex].position, (points[curIndex + 1].position) / 2, points[curIndex + 1].position, t.value);
        }

        else if(curIndex == points.Length - 2)
        {
            interpolate.transform.position =
                QuadraticBezierCurve.QuadraticInterpolation(points[curIndex].position, (points[curIndex - 1].position + points[curIndex + 1].position) / 2, points[curIndex + 1].position, t.value);
        }
        else
        {
            interpolate.transform.position =
                QuadraticBezierCurve.QuadraticInterpolation(points[curIndex].position, (points[curIndex-1].position + points[curIndex + 1].position) / 2, points[curIndex + 1].position, t.value);
        }
        //interpolate.transform.position = 
        //    QuadraticBezierCurve.QuadraticInterpolation(points[curIndex].position, (points[curIndex+2].position + points[curIndex+1].position) / 2, points[curIndex+1].position, t.value);        
    }
}
