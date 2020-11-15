using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MathsOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

// this makes things a dropdown?
// Removing the MonoBehavior here because you don't need to trigger things.
[System.Serializable]
public class Problem
{
    // #a && operator && #b
    // Answers A-D, with only one correct.
    // Correct answer will be an index of the array

    // Initialize variables
    public float firstNumber;
    public float secondNumber;
    public MathsOperation operation;
    public float[] answers;

    public int correctTube;
    
}
