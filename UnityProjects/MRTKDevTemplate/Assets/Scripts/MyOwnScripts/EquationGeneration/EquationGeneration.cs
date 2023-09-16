using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MathNet.Numerics;
using MathNet.Numerics.RootFinding;

public class EquationGeneration : MonoBehaviour
{
    public static EquationGeneration instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject equalBlock;
    public GameObject termBlock;
    public List<GameObject> leftSideBlocks;
    public List<GameObject> rightSideBlocks;
    public Transform equationOriginPoint;
    public int maxValueSide = 4;
    public int maxTermValue = 9;
    public List<char> mathOperators = new List<char>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateEquationBlocks();
    }

    public void GenerateEquationBlocks()
    {
        InstantiateEqualBlock();
        SetupMathOperators();

        maxTermValue = Random.Range(1, maxTermValue);
        InstantiateLeftBlocks(maxTermValue);

        maxTermValue = Random.Range(1, maxTermValue);
        InstantiateRightBlocks(maxTermValue);

        EquationData.GenerateEquationString();
    }

    private void InstantiateEqualBlock()
    {
        Instantiate(equalBlock, equationOriginPoint.position, Quaternion.identity);
    }

    private void InstantiateLeftBlocks(int maxTermValue)
    {
        int leftSideBlocksAmount = Random.Range(1, maxValueSide);
        bool randomVariableChance = Random.Range(0, 2) == 1;
        float xOffset = -3.5f; // Start at offset for the first block

        for (int i = 0; i < leftSideBlocksAmount; i++)
        {
            int randomTermValue = Random.Range(-maxTermValue, maxTermValue);
            int randomMathOperatorValue = Random.Range(0, mathOperators.Count);
            char randomMathOperator = mathOperators[randomMathOperatorValue];

            string termValueToSave = "";
            string variableToSave = "";
            string mathOperatorToSave = "";

            // Instantiate the block at the current position.
            GameObject newBlock = Instantiate(termBlock, new Vector3(
                equationOriginPoint.position.x + xOffset,
                equationOriginPoint.position.y,
                equationOriginPoint.position.z), Quaternion.identity);

            TMP_Text textComponent = newBlock.GetComponentInChildren<TMP_Text>();

            // Goofy ah- code I know, but deal with it
            if (i % 2 == 0)
            {
                if (randomVariableChance)
                {
                    if (randomTermValue != 0)
                    {
                        textComponent.text = randomTermValue.ToString() + 'x';
                        termValueToSave = randomTermValue.ToString();
                        variableToSave = "x";
                    } else
                    {
                        textComponent.text = "x";
                        variableToSave = "x";
                    }
                    randomVariableChance = false;
                }
                else
                {
                    textComponent.text = randomTermValue.ToString();
                    termValueToSave = randomTermValue.ToString();
                }
            }
            else
            {
                textComponent.text = randomMathOperator.ToString();
                mathOperatorToSave = randomMathOperator.ToString();
            }

            if (i == leftSideBlocksAmount - 1 && leftSideBlocksAmount % 2 == 0) // If it reached the end and it's odd, destroy
            {
                Destroy(newBlock);
                mathOperatorToSave = "";
            }

            EquationData.leftMathBlockList.Add(new MathBlock(newBlock, termValueToSave, variableToSave, mathOperatorToSave));

            xOffset -= 3.5f;
        }
    } // Consolidate this into one by just bringing in a pos/neg param

    private void InstantiateRightBlocks(int maxTermValue)
    {
        int rightSideBlocksAmount = Random.Range(1, maxValueSide);
        bool randomVariableChance = Random.Range(0, 2) == 1;
        float xOffset = 3.5f; // Start at offset for the first block

        for (int i = 0; i < rightSideBlocksAmount; i++)
        {
            int randomTermValue = Random.Range(-maxTermValue, maxTermValue);
            int randomMathOperatorValue = Random.Range(0, mathOperators.Count);
            char randomMathOperator = mathOperators[randomMathOperatorValue];

            string termValueToSave = "";
            string variableToSave = "";
            string mathOperatorToSave = "";

            // Instantiate the block at the current position.
            GameObject newBlock = Instantiate(termBlock, new Vector3(
                equationOriginPoint.position.x + xOffset,
                equationOriginPoint.position.y,
                equationOriginPoint.position.z), Quaternion.identity);

            TMP_Text textComponent = newBlock.GetComponentInChildren<TMP_Text>();

            // Goofy ah- code I know, but deal with it
            if (i % 2 == 0)
            {
                if (randomVariableChance)
                {
                    if (randomTermValue != 0)
                    {
                        textComponent.text = randomTermValue.ToString() + 'x';
                        termValueToSave = randomTermValue.ToString();
                        variableToSave = "x";
                    }
                    else
                    {
                        textComponent.text = "x";
                        variableToSave = "x";
                    }
                    randomVariableChance = false;
                }
                else
                {
                    textComponent.text = randomTermValue.ToString();
                    termValueToSave = randomTermValue.ToString();
                }
            }
            else
            {
                textComponent.text = randomMathOperator.ToString();
                mathOperatorToSave = randomMathOperator.ToString();
            }

            if (i == rightSideBlocksAmount - 1 && rightSideBlocksAmount % 2 == 0) // If it reached the end and it's odd, destroy
            {
                Destroy(newBlock);
                mathOperatorToSave = "";
            }

            EquationData.rightMathBlockList.Add(new MathBlock(newBlock, termValueToSave, variableToSave, mathOperatorToSave));

            xOffset += 3.5f;
        }
    } // Consolidate this into one by just bringing in a pos/neg param

    private void SetupMathOperators()
    {
        mathOperators.Add('+');
        mathOperators.Add('-');
        mathOperators.Add('*');
        mathOperators.Add('/');
    }

    private void ClearBlocks()
    {
        foreach (GameObject block in leftSideBlocks)
        {
            Destroy(block);
        }
        foreach (GameObject block in rightSideBlocks)
        {
            Destroy(block);
        }
        Destroy(equalBlock);
        leftSideBlocks.Clear();
        rightSideBlocks.Clear();
    }
}
