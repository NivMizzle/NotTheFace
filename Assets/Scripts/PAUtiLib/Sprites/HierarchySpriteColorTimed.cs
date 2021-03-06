﻿// Author(s): Paul Calande
// Changes the sprite color for a certain amount of time before changing it back.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierarchySpriteColorTimed : MonoBehaviour
{
    [SerializeField]
    TimeScale timeScale;
    [SerializeField]
    [Tooltip("The component to use to color the sprite.")]
    HierarchySpriteColor hierarchySpriteColor;
    [SerializeField]
    [Tooltip("The color for the object to be when the timer is running.")]
    Color colorChanged = Color.red;
    [SerializeField]
    [Tooltip("How many seconds the object should use the different color.")]
    float secondsToColor = 0.1f;

    Timer timerColor;
    Color colorNormal = Color.white;

    private void Start()
    {
        timerColor = new Timer(secondsToColor, ColorBackToDefault, false, false);
    }

    // Change the color and start the timer.
    public void ColorStart()
    {
        hierarchySpriteColor.SetColor(colorChanged);
        timerColor.Reset();
        timerColor.Start();
    }

    // Stop the timer and revert the color back to normal.
    public void ColorEnd()
    {
        timerColor.Stop();
        ColorBackToDefault(0.0f);
    }

    // Returns true if the timer is running.
    public bool IsRunning()
    {
        return timerColor.IsRunning();
    }

    // Callback function for timer.
    private void ColorBackToDefault(float secondsOverflow)
    {
        hierarchySpriteColor.SetColor(colorNormal);
    }

    private void FixedUpdate()
    {
        timerColor.Tick(timeScale.DeltaTime());
    }
}