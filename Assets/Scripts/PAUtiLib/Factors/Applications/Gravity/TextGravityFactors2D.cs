﻿// Author(s): Paul Calande
// Displays the product of some factors.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextGravityFactors2D : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The text to display the rate in.")]
    Text text;
    [SerializeField]
    [Tooltip("The component to retrieve the rate from.")]
    GravityFactors2D source;

    private void Start()
    {
        SetRate(1.0f);
        source.AddProductUpdatedCallback(SetRate);
    }

    private void SetRate(float newRate)
    {
        text.text = "GRAVITY: x" + newRate;
    }
}