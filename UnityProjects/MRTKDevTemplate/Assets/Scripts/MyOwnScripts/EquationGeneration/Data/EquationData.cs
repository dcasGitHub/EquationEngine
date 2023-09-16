using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public static class EquationData 
{
    public static List<MathBlock> leftMathBlockList = new List<MathBlock>();
    public static List<MathBlock> rightMathBlockList = new List<MathBlock>();
    public static string equationString;

    public static void GenerateEquationString()
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
            EquationGeneration.instance.GenerateEquationBlocks();
        }

        Debug.Log(equationString);
    }
}
