using Fungus;

[CommandInfo("Flow", "Auto Save Load Point", "Set Auto Save Point")]
public class AutoSavePoint : SavePoint
{
    private Variable _step;
    protected void Awake()
    {
        _step = FungusManager.Instance.GlobalVariables.GetOrAddVariable("Step", 0, typeof(IntegerVariable));
    }
    public override void OnEnter()
    {
        _step.Apply(SetOperator.Assign, 0);
        base.OnEnter();
    }
}