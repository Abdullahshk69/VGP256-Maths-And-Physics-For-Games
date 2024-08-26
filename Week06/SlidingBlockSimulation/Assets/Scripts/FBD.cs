using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class FBD : MonoBehaviour
{
    // Predetermined values
    private float coefFriction = 0.5f;  // friction between 2 wooden objects

    private float g = 9.8f;
    private Vector2 v0 = Vector2.zero;
    private float angle;
    [SerializeField] private float m;
    [SerializeField] private Rigidbody2D rb;

    // Calculated variables
    private float criticalAngle;

    // Forces
    private Vector2 gravForce;
    private Vector2 normalForce;
    private Vector2 frictionalForce;

    // To find
    private Vector2 netForce;
    [SerializeField] private float appliedForce;

    private void Start()
    {
        angle = transform.rotation.z;
        gravForce = m * g * Vector2.down;

        normalForce = Vector2.zero; // m * g * cos(theta)
        frictionalForce = new Vector2
            (
                coefFriction * m * g * Mathf.Cos(angle),
                0
            );

        Debug.Log("friction: " + frictionalForce);
    }

    private void Update()
    {
        angle = transform.rotation.z;
        //normalForce = new Vector2(-mass * g * Mathf.Sin(angle), mass * g * Mathf.Cos(angle));
        //normalForce = m * g * Mathf.Cos(angle) * Vector2.up;


        //netForce = frictionalForce + normalForce + gravForce;

        netForce = new Vector2
        (
            Mathf.Clamp(appliedForce - frictionalForce.x, 0.0f, appliedForce),
            0.0f
        );
    }

    private void FixedUpdate()
    {
        rb.AddForce(netForce);
        rb.AddForce(gravForce);
        rb.AddForce(normalForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, gravForce);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, normalForce);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //normalForce = m * g * new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
        normalForce = -gravForce;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        normalForce = Vector2.zero;
    }
}
