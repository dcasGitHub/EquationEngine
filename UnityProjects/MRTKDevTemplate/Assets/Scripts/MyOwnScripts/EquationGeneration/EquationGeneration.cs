using System.Collections.Generic;
using UnityEngine;
using MathNet.Numerics;
using MathNet.Numerics.RootFinding;
using TMPro;

public class EquationGeneration : MonoBehaviour
{
    public List<MathBlock> mathBlockList = new List<MathBlock>();
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
        InstantiateEqualBlock();
        SetupMathOperators();

        maxTermValue = Random.Range(1, maxTermValue);
        InstantiateLeftBlocks(maxTermValue);

        maxTermValue = Random.Range(1, maxTermValue);
        InstantiateRightBlocks(maxTermValue);
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

            // Instantiate the block at the current position.
            GameObject newBlock = Instantiate(termBlock, new Vector3(
                equationOriginPoint.position.x + xOffset,
                equationOriginPoint.position.y,
                equationOriginPoint.position.z), Quaternion.identity);

            TMP_Text textComponent = newBlock.GetComponentInChildren<TMP_Text>();

            if (i % 2 == 0)
            {
                if (randomVariableChance)
                {
                    if (randomTermValue != 0)
                    {
                        textComponent.text = randomTermValue.ToString() + 'x';
                    } else
                    {
                        textComponent.text = "x";
                    }
                    randomVariableChance = false;
                }
                else
                {
                    textComponent.text = randomTermValue.ToString();
                }
                mathBlockList.Add(new MathBlock(newBlock, randomTermValue, randomVariableChance ? 'x' : ' ', ' '));
            }
            else
            {
                char randomMathOperator = mathOperators[randomMathOperatorValue];
                textComponent.text = randomMathOperator.ToString();
                mathBlockList.Add(new MathBlock(newBlock, randomTermValue, randomVariableChance ? 'x' : ' ', randomMathOperator));
            }

            if (i == leftSideBlocksAmount - 1 && leftSideBlocksAmount % 2 == 0) // If it reached the end and it's odd, destroy
            {
                Destroy(newBlock);
            }

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
            int randomTermValue = Random.Range(1, maxTermValue);
            int randomMathOperatorValue = Random.Range(0, mathOperators.Count);

            // Instantiate the block at the current position.
            GameObject newBlock = Instantiate(termBlock, new Vector3(
                equationOriginPoint.position.x + xOffset,
                equationOriginPoint.position.y,
                equationOriginPoint.position.z), Quaternion.identity);

            TMP_Text textComponent = newBlock.GetComponentInChildren<TMP_Text>();

            if (i % 2 == 0)
            {
                if (randomVariableChance)
                {
                    textComponent.text = randomTermValue.ToString() + 'x';
                    randomVariableChance = false;
                }
                else
                {
                    textComponent.text = randomTermValue.ToString();
                }
                mathBlockList.Add(new MathBlock(newBlock, randomTermValue, randomVariableChance ? 'x' : ' ', ' '));
            }
            else
            {
                char randomMathOperator = mathOperators[randomMathOperatorValue];
                textComponent.text = randomMathOperator.ToString();
                mathBlockList.Add(new MathBlock(newBlock, randomTermValue, randomVariableChance ? 'x' : ' ', randomMathOperator));
            }

            if (i == rightSideBlocksAmount - 1 && rightSideBlocksAmount % 2 == 0) // If it reached the end and it's odd, destroy
            {
                Destroy(newBlock);
            }

            xOffset += 3.5f;
        }
    } 

    private void SetupMathOperators()
    {
        mathOperators.Add('+');
        mathOperators.Add('-');
        mathOperators.Add('*');
        mathOperators.Add('/');
    }
}
