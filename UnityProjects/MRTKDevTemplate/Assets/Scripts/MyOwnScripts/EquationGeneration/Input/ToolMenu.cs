using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ToolMenu : MonoBehaviour
{
    public TMP_Text currentInstructionsText;
    public Dictionary<string, bool> operationStates = new Dictionary<string, bool>();
    public static int choiceCount = 0;

    public void OnAwake()
    {
        /*operationStates.Add("Distribution", false);
        operationStates.Add("Exponents", false);
        operationStates.Add("Addition", false);
        operationStates.Add("Subtraction", false);
        operationStates.Add("Multiplication", false);
        operationStates.Add("Division", false);*/
        operationStates.Add("Inverse", false);
    }

    private void Start()
    {
        currentInstructionsText.text = "Welcome!\nSelect an option in the Tool Menu.";
    }

    private void Update()
    {
        /*if (EquationData.operationPairs["Multiplication"] == true)
        {
            if (EquationData.mathBlocksSelected.Count == 1)
            {
                currentInstructionsText.text = "Select the second term to edit (Right Side).";
            }
            if (EquationData.mathBlocksSelected.Count == 2)
            {
                Debug.Log("Display bottom operations for both sides, and change equation after edit");
            }
        }*/
        if (EquationData.operationPairs["Inverse"] == true)
        {
            if (EquationData.mathBlocksSelected.Count == 1)
            {
                currentInstructionsText.text = "Select the second term to edit (Right Side).";
            }
            if (EquationData.mathBlocksSelected.Count == 2)
            {
                Debug.Log("Display bottom operations for both sides, and change equation after edit.");
            }
        }
    }

    public void InverseButton()
    {
        if (choiceCount == 0)
        {
            operationStates["Inverse"] = true;
            currentInstructionsText.text = "You are in Inverse Mode.\n Select the first term to edit (Left Side).";
        }
        else
        {
            currentInstructionsText.text = "No addition and subtraction pairs found.";
        }
    }

    public void SolveButton()
    {
        currentInstructionsText.text = "You are in Solver Mode.\n X = " + EquationData.CheckAnswer();
    }

    public void ResetButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*public void DistributionButton()
    {
        currentInstructionsText.text = "No parenthesis.\nSelect another option below.";
    }

    public void ExponentsButton()
    {
        currentInstructionsText.text = "No exponents.\nSelect another option below.";
    }

    public void AdditionButton()
    {
        if (choiceCount == 0 && EquationData.operationPairs["Addition"] == true)
        {
            operationStates["Addition"] = true;
            currentInstructionsText.text = "You are in Addition Mode.\n Select the first term to edit (Left Side).";
        }
        else
        {
            currentInstructionsText.text = "No addition and subtraction pairs found.";
        }
    }

    public void SubtractionButton()
    {
        if (choiceCount == 0 && EquationData.operationPairs["Subtraction"] == true)
        {
            operationStates["Subtraction"] = true;
            currentInstructionsText.text = "You are in Subtraction Mode.\n Select the first term to edit (Left Side).";
        }
        else
        {
            currentInstructionsText.text = "No subtraction and addition pairs found.";
        }
    }

    public void MultiplicationButton()
    {
        if (choiceCount == 0 && EquationData.operationPairs["Multiplication"] == true)
        {
            operationStates["Multiplication"] = true;
            currentInstructionsText.text = "You are in Multiplication Mode.\n Select the first term to edit (Left Side).";
        }
        else
        {
            currentInstructionsText.text = "No multiplication and division pairs found.";
        }
    }

    public void DivisionButton()
    {
        if (choiceCount == 0 && EquationData.operationPairs["Division"] == true)
        {
            operationStates["Division"] = true;
            currentInstructionsText.text = "You are in Division Mode.\n Select the first term to edit (Left Side).";
        }
        else
        {
            currentInstructionsText.text = "No division and multiplication pairs found.";
        }
    }*/
}
