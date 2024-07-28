using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using UnityEngine;

public struct Matrix4x4
{
    public float _11, _12, _13, _14,
                _21, _22, _23, _24,
                _31, _32, _33, _34,
                _41, _42, _43, _44;

    public Matrix4x4(bool identity)
    {
        this = new Matrix4x4(
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public Matrix4x4(
        float a11, float a12, float a13, float a14,
        float a21, float a22, float a23, float a24,
        float a31, float a32, float a33, float a34,
        float a41, float a42, float a43, float a44)
    {
        _11 = a11; _12 = a12; _13 = a13; _14 = a14;
        _21 = a21; _22 = a22; _23 = a23; _24 = a24;
        _31 = a31; _32 = a32; _33 = a33; _34 = a34;
        _41 = a41; _42 = a42; _43 = a43; _44 = a44;
    }

    static public Matrix4x4 operator+(Matrix4x4 lhs, Matrix4x4 rhs)
    {
        return new Matrix4x4(
            lhs._11 + rhs._11, lhs._12 + rhs._12, lhs._13 + rhs._13, lhs._14 + rhs._14,
            lhs._21 + rhs._21, lhs._22 + rhs._22, lhs._23 + rhs._23, lhs._24 + rhs._24,
            lhs._31 + rhs._31, lhs._32 + rhs._32, lhs._33 + rhs._33, lhs._34 + rhs._34,
            lhs._41 + rhs._41, lhs._42 + rhs._42, lhs._43 + rhs._43, lhs._44 + rhs._44
            );
    }

    static public Matrix4x4 operator*(Matrix4x4 lhs, float s)
    {
        return new Matrix4x4(
            lhs._11 * s, lhs._12 * s, lhs._13 * s, lhs._14 * s,
            lhs._21 * s, lhs._22 * s, lhs._23 * s, lhs._24 * s,
            lhs._31 * s, lhs._32 * s, lhs._33 * s, lhs._34 * s,
            lhs._41 * s, lhs._42 * s, lhs._43 * s, lhs._44 * s
            );
    }

    static public Matrix4x4 operator*(Matrix4x4 lhs, Matrix4x4 rhs)
    {
        return new Matrix4x4(
            (lhs._11 * rhs._11) + (lhs._12 * rhs._21) + (lhs._13 * rhs._31) + (lhs._14 * rhs._41),
            (lhs._11 * rhs._12) + (lhs._12 * rhs._22) + (lhs._13 * rhs._32) + (lhs._14 * rhs._42),
            (lhs._11 * rhs._13) + (lhs._12 * rhs._23) + (lhs._13 * rhs._33) + (lhs._14 * rhs._43),
            (lhs._11 * rhs._14) + (lhs._12 * rhs._24) + (lhs._13 * rhs._34) + (lhs._14 * rhs._44),

            (lhs._21 * rhs._11) + (lhs._22 * rhs._21) + (lhs._23 * rhs._31) + (lhs._24 * rhs._41),
            (lhs._21 * rhs._12) + (lhs._22 * rhs._22) + (lhs._23 * rhs._32) + (lhs._24 * rhs._42),
            (lhs._21 * rhs._13) + (lhs._22 * rhs._23) + (lhs._23 * rhs._33) + (lhs._24 * rhs._43),
            (lhs._21 * rhs._14) + (lhs._22 * rhs._24) + (lhs._23 * rhs._34) + (lhs._24 * rhs._44),

            (lhs._31 * rhs._11) + (lhs._32 * rhs._21) + (lhs._33 * rhs._31) + (lhs._34 * rhs._41),
            (lhs._31 * rhs._12) + (lhs._32 * rhs._22) + (lhs._33 * rhs._32) + (lhs._34 * rhs._42),
            (lhs._31 * rhs._13) + (lhs._32 * rhs._23) + (lhs._33 * rhs._33) + (lhs._34 * rhs._43),
            (lhs._31 * rhs._14) + (lhs._32 * rhs._24) + (lhs._33 * rhs._34) + (lhs._34 * rhs._44),

            (lhs._41 * rhs._11) + (lhs._42 * rhs._21) + (lhs._43 * rhs._31) + (lhs._44 * rhs._41),
            (lhs._41 * rhs._12) + (lhs._42 * rhs._22) + (lhs._43 * rhs._32) + (lhs._44 * rhs._42),
            (lhs._41 * rhs._13) + (lhs._42 * rhs._23) + (lhs._43 * rhs._33) + (lhs._44 * rhs._43),
            (lhs._41 * rhs._14) + (lhs._42 * rhs._24) + (lhs._43 * rhs._34) + (lhs._44 * rhs._44)
            );
    }

    public static Matrix4x4 Identity()
    {
        return new Matrix4x4(
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 RotationX(float rad)
    {
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);

        return new Matrix4x4(
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f,    c,   -s, 0.0f,
            0.0f,    s,    c, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 RotationY(float rad)
    {
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);

        return new Matrix4x4(
               c, 0.0f,    s, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
              -s, 0.0f,    c, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 RotationZ(float rad)
    {
        float s = Mathf.Sin(rad);
        float c = Mathf.Cos(rad);

        return new Matrix4x4(
               c,   -s, 0.0f, 0.0f,
               s,    c, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 Scaling(float s)
    {
        return new Matrix4x4(
               s, 0.0f, 0.0f, 0.0f,
            0.0f,    s, 0.0f, 0.0f,
            0.0f, 0.0f,    s, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 Scaling(Vector3 s)
    {
        return new Matrix4x4(
            s.x, 0.0f, 0.0f, 0.0f,
            0.0f, s.y, 0.0f, 0.0f,
            0.0f, 0.0f, s.z, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 Scaling(float sx, float sy, float sz)
    {
        return new Matrix4x4(
            sx, 0.0f, 0.0f, 0.0f,
            0.0f, sy, 0.0f, 0.0f,
            0.0f, 0.0f, sz, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
            );
    }

    public static Matrix4x4 Translation(Vector3 t)
    {
        return new Matrix4x4(
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
             t.x,  t.y,  t.z, 1.0f
            );
    }

    public static Matrix4x4 Translation(float tx, float ty, float tz)
    {
        return new Matrix4x4(
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
              tx,   ty,   tz, 1.0f
            );
    }

    public Vector3 GetPosition()
    {
        return new Vector3(_41, _42, _43);
    }
}
