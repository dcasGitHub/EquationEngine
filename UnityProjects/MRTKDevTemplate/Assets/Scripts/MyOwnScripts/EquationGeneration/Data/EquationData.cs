using System;
using System.Collections.Generic;
using UnityEngine;
using AngouriMath.Extensions;
using UnityEngine.Windows;
using System.Buffers;

public static class EquationData 
{
    public static List<MathBlock> leftMathBlockList = new List<MathBlock>();
    public static List<MathBlock> rightMathBlockList = new List<MathBlock>();
    public static Dictionary<string, bool> operationPairs = new Dictionary<string, bool>();
    public static List<MathBlock> mathBlocksSelected = new List<MathBlock>();
    public static string equationString;

    static EquationData()
    {
        /*operationPairs.Add("Distribution", false);
        operationPairs.Add("Exponents", false);
        operationPairs.Add("Addition", false);
        operationPairs.Add("Subtraction", false);
        operationPairs.Add("Multiplication", false);
        operationPairs.Add("Division", false);*/
        operationPairs.Add("Inverse", false);
    }

    public static string GenerateEquationString()
    {
        List<MathBlock> reverseLeftMathBlockList = new List<MathBlock>(leftMathBlockList);
        reverseLeftMathBlockList.Reverse();

        foreach (MathBlock mathBlock in reverseLeftMathBlockList)
        {
            equationString += mathBlock.Value + mathBlock.Variable + mathBlock.Operator;
        }

        equationString += "=";

        foreach (MathBlock mathBlock in rightMathBlockList)
        {
            equationString += mathBlock.Value + mathBlock.Variable + mathBlock.Operator;
        }

        if (!equationString.Contains('x'))
        {
            Debug.Log("Reset!");
            // EquationGeneration.instance.GenerateEquationBlocks();
        }

        Debug.Log(equationString);
        return equationString;
    }

    /*public static void CheckForOperationPairs()
    {
        string[] parts = GenerateEquationString().Split('=');

        string leftSide = parts[0];
        string rightSide = parts[1];

        if (leftSide.Contains('+') && rightSide.Contains('-') ||
            leftSide.Contains('-') && rightSide.Contains('+'))
        {
            operationPairs["Addition"] = true;
            operationPairs["Subtraction"] = true;
        }

        if (leftSide.Contains('*') && rightSide.Contains('/') ||
            leftSide.Contains('/') && rightSide.Contains('*'))
        {
            operationPairs["Multiplication"] = true;
            operationPairs["Division"] = true;
        }
    }*/

    public static string CheckAnswer()
    {
        Debug.Log(GenerateEquationString().Solve("x").Simplify());
        return GenerateEquationString().Solve("x").Simplify().ToString();
    }
}
