using UnityEngine;

public class MathBlock
{
    public GameObject blockModel;
    private float value;
    private char variable;
    private char mathOperator;

    public MathBlock(GameObject blockModel, float value, char variable, char mathOperator)
    {
        this.blockModel = blockModel;
        this.value = value;
        this.variable = variable;
        this.mathOperator = mathOperator;
    }

    public GameObject BlockModel
    {
        get { return blockModel; }
        set { this.blockModel = blockModel; }
    }

    public float Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public char Variable
    {
        get { return variable; }
        set { variable = value; }
    }

    public char Operator
    {
        get { return mathOperator; }
        set { mathOperator = value; }
    }
}
