using System.Collections.Generic;
using UnityEngine;

public class WaterSurface : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public List<Vector3> controlPoints = new List<Vector3>();
    public int splineResolution = 10;
    public float waveAmplitude = 0.5f;
    public float waveSpeed = 2f;

    private float waveOffset = 0f;
    private bool isRippling = false;
    private Vector3 rippleCenter;
    private float rippleTime = 0f;
    private float rippleDuration = 2f;

    // Tsunami-related variables
    private bool isTsunamiActive = false;
    private float tsunamiTime = 0f;
    private float tsunamiDuration = 5f;
    private float tsunamiSpeed = 5f;
    private float tsunamiAmplitude = 3f;
    private Vector3 tsunamiDirection;
    private int tsunamiStartPoint = 0;

    void Start()
    {
        lineRenderer.positionCount = (controlPoints.Count - 1) * splineResolution;
        lineRenderer.loop = false;
        lineRenderer.useWorldSpace = false;
        
    }

    void Update()
    {
        HandleMouseInput();
        waveOffset += Time.deltaTime * waveSpeed;
        UpdateWaterSurface();
    }

    void HandleMouseInput()
    {
        // Left click for ripple
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            rippleCenter = FindClosestControlPoint(worldPos);
            rippleTime = 0f;
            isRippling = true;
        }

        // Right click for tsunami
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            tsunamiStartPoint = FindClosestControlPointIndex(worldPos);
            tsunamiDirection = Vector3.right; // Assuming the wave moves to the right, modify this for other directions
            tsunamiTime = 0f;
            isTsunamiActive = true;
        }

        // Update ripple over time
        if (isRippling)
        {
            rippleTime += Time.deltaTime;
            if (rippleTime > rippleDuration)
            {
                isRippling = false;
            }
        }

        // Update tsunami over time
        if (isTsunamiActive)
        {
            tsunamiTime += Time.deltaTime;
            if (tsunamiTime > tsunamiDuration)
            {
                isTsunamiActive = false;
            }
        }
    }

    Vector3 FindClosestControlPoint(Vector3 clickPos)
    {
        Vector3 closestPoint = controlPoints[0];
        float minDist = Vector3.Distance(closestPoint, clickPos);

        foreach (var point in controlPoints)
        {
            float dist = Vector3.Distance(point, clickPos);
            if (dist < minDist)
            {
                minDist = dist;
                closestPoint = point;
            }
        }

        return closestPoint;
    }

    int FindClosestControlPointIndex(Vector3 clickPos)
    {
        int closestIndex = 0;
        float minDist = Vector3.Distance(controlPoints[0], clickPos);

        for (int i = 0; i < controlPoints.Count; i++)
        {
            float dist = Vector3.Distance(controlPoints[i], clickPos);
            if (dist < minDist)
            {
                minDist = dist;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    void UpdateWaterSurface()
    {
        List<Vector3> splinePoints = new List<Vector3>();

        for (int i = 0; i < controlPoints.Count - 1; i++)
        {
            Vector3 p0 = i == 0 ? controlPoints[i] : controlPoints[i - 1];
            Vector3 p1 = controlPoints[i];
            Vector3 p2 = controlPoints[i + 1];
            Vector3 p3 = i == controlPoints.Count - 2 ? controlPoints[i + 1] : controlPoints[i + 2];

            for (int j = 0; j < splineResolution; j++)
            {
                float t = j / (float)splineResolution;
                Vector3 interpolatedPoint = CatmullRom(p0, p1, p2, p3, t);

                // Apply wave and ripple effect
                float wave = Mathf.Sin(t * Mathf.PI * 2f + waveOffset) * waveAmplitude;
                float ripple = isRippling ? ApplyRipple(interpolatedPoint) : 0f;

                // Apply tsunami effect
                float tsunami = isTsunamiActive ? ApplyTsunami(i, interpolatedPoint) : 0f;

                interpolatedPoint.y += wave + ripple + tsunami;
                splinePoints.Add(interpolatedPoint);
            }
        }

        lineRenderer.positionCount = splinePoints.Count;
        lineRenderer.SetPositions(splinePoints.ToArray());
    }

    float ApplyRipple(Vector3 point)
    {
        float distFromRipple = Vector3.Distance(point, rippleCenter);
        float rippleEffect = Mathf.Sin(distFromRipple * 5f - rippleTime * 10f) * Mathf.Exp(-distFromRipple * 2f) * (rippleDuration - rippleTime);
        return rippleEffect;
    }

    float ApplyTsunami(int pointIndex, Vector3 point)
    {
        // Determine how far the point is from the start of the tsunami wave
        float distanceFromTsunami = pointIndex - tsunamiStartPoint;

        if (distanceFromTsunami < 0 || distanceFromTsunami > 10) // Limit the wave to affect nearby points
        {
            return 0f;
        }

        float tsunamiEffect = Mathf.Sin(distanceFromTsunami - tsunamiTime * tsunamiSpeed) * tsunamiAmplitude * Mathf.Exp(-distanceFromTsunami * 0.5f);
        return tsunamiEffect;
    }

    Vector3 CatmullRom(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float t2 = t * t;
        float t3 = t2 * t;

        Vector3 result = 0.5f * ((2f * p1) +
                                 (-p0 + p2) * t +
                                 (2f * p0 - 5f * p1 + 4f * p2 - p3) * t2 +
                                 (-p0 + 3f * p1 - 3f * p2 + p3) * t3);

        return result;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (var point in controlPoints)
        {
            Gizmos.DrawSphere(point, 0.1f);
        }
    }
}
