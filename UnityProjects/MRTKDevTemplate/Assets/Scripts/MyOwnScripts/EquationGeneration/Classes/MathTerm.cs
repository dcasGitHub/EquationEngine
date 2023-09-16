using UnityEngine;

public class MathBlock
{
    public GameObject blockModel;
    private string value;
    private string variable;
    private string mathOperator;

    public MathBlock(GameObject blockModel, string value, string variable, string mathOperator)
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

    public string Value
    {
        get { return value; }
        set { this.value = value; }
    }

    public string Variable
    {
        get { return variable; }
        set { variable = value; }
    }

    public string Operator
    {
        get { return mathOperator; }
        set { mathOperator = value; }
    }
}
