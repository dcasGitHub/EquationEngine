using MixedReality.Toolkit.UX;
using UnityEngine;

public class MathBlock : MonoBehaviour
{
    public GameObject blockModel;
    private string value;
    private string variable;
    private string mathOperator;
    private bool leftRightSide;

    public MathBlock(GameObject blockModel, string value, string variable, string mathOperator, bool leftRightSide)
    {
        this.blockModel = blockModel;
        this.value = value;
        this.variable = variable;
        this.mathOperator = mathOperator;
        this.leftRightSide = leftRightSide;
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

    public bool LeftRightSide
    {
        get { return leftRightSide; }
        set { leftRightSide = value; }
    }

    private void OnEnable()
    {
        PressableButton pressableButton = transform.GetChild(0).GetComponent<PressableButton>();
        pressableButton.OnClicked.AddListener(OnTouched);
    }

    public void OnTouched()
    {
        Debug.Log(value + " " + variable + " " + mathOperator);
        EquationData.mathBlocksSelected.Add(new MathBlock(BlockModel, Value, Variable, Operator, LeftRightSide));
        ToolMenu.choiceCount++;
    }
}
