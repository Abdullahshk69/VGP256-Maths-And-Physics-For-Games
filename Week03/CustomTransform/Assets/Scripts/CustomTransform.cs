using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomTransform : MonoBehaviour
{
    [SerializeField] Transform unityTransform;
    public Matrix4x4 matrix;
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 scale;
    [SerializeField] private Vector3 rotation;


    private void Start()
    {
        matrix = Matrix4x4.Identity();
    }

    private void Update()
    {
        matrix = Matrix4x4.Identity();

        Scale();

        RotateX();
        RotateY();
        RotateZ();

        Translate();

        unityTransform.localScale = MatrixToScale(matrix);
        unityTransform.rotation = MatrixToRotation(matrix);
        unityTransform.localPosition = MatrixToPosition(matrix);
    }

    public void RotateX()
    {
        matrix *= Matrix4x4.RotationX(rotation.x * Mathf.Deg2Rad);
    }

    public void RotateY()
    {
        matrix *= Matrix4x4.RotationY(rotation.y * Mathf.Deg2Rad);
    }

    public void RotateZ()
    {
        matrix *= Matrix4x4.RotationZ(rotation.z * Mathf.Deg2Rad);
    }

    public void Translate()
    {
        matrix *= Matrix4x4.Translation(position);
    }

    public void Scale()
    {
        matrix *= Matrix4x4.Scaling(scale);
    }

    public Vector3 MatrixToPosition(Matrix4x4 matrix)
    {
        return new Vector3(matrix._41, matrix._42, matrix._43);
    }

    public Quaternion MatrixToRotation(Matrix4x4 matrix)
    {
        Vector3 forward;
        forward.x = matrix._12;
        forward.y = matrix._22;
        forward.z = matrix._32;

        Vector3 upwards;
        upwards.x = matrix._11;
        upwards.y = matrix._21;
        upwards.z = matrix._31;

        return Quaternion.LookRotation(forward, upwards);
    }

    public Vector3 MatrixToScale(Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector3(matrix._11, matrix._21, matrix._31).magnitude;
        scale.y = new Vector3(matrix._12, matrix._22, matrix._32).magnitude;
        scale.z = new Vector3(matrix._13, matrix._23, matrix._33).magnitude;
        return scale;
    }
}
