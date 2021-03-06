﻿// Author(s): Paul Calande
// Script that tracks the current "up" direction of the GameObject.
// This is used for checking whether the player is on the ground, among other things.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDirection2D : MonoBehaviour
{
    // Invoked when the up angle is changed.
    public delegate void UpAngleChangedHandler();
    public event UpAngleChangedHandler UpAngleChanged;

    [SerializeField]
    [Tooltip("The angle corresponding to the upwards direction.")]
    float upAngle = 90.0f;

    private void Awake()
    {
        NormalizeAngle();
    }

    // Returns the angle corresponding to the upwards direction.
    public float GetUpAngle()
    {
        return upAngle;
    }

    private void NormalizeAngle()
    {
        upAngle = UtilCircle.AngleDegreesToUnsignedRange(upAngle);
    }

    // Changes the angle corresponding to the upwards direction.
    public void SetUpAngle(float angle)
    {
        upAngle = angle;
        NormalizeAngle();
        OnUpAngleChanged();
    }

    // Sets the up angle based on the given down angle.
    public void SetDownAngle(float angle)
    {
        SetUpAngle(angle + 180.0f);
    }

    // Returns the vector corresponding to the upwards direction.
    public Vector2 GetUpVector()
    {
        return UtilHeading2D.HeadingVectorFromDegrees(upAngle);
    }
    
    // Returns the vector corresponding to the downwards direction.
    public Vector2 GetDownVector()
    {
        return -GetUpVector();
    }

    // Returns a version of the given vector that's rotated to have its y axis match the
    // upwards direction that this script defines.
    public Vector2 SpaceEnter(Vector2 toTransform)
    {
        return Quaternion.Euler(0.0f, 0.0f, 90.0f - upAngle) * toTransform;
    }

    // Inverse transformation of the SpaceEnter function.
    public Vector2 SpaceExit(Vector2 toTransform)
    {
        return Quaternion.Euler(0.0f, 0.0f, upAngle - 90.0f) * toTransform;
    }

    private void OnUpAngleChanged()
    {
        if (UpAngleChanged != null)
        {
            UpAngleChanged();
        }
    }
}