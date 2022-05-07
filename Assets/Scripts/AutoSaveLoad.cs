using Fungus;

[CommandInfo("Flow", "AutoSave Load", "Auto Load after save")]
public class AutoSaveLoad : Command
{
    private Variable _step;
    private void Awake()
    {
        _step = FungusManager.Instance.GlobalVariables.GetOrAddVariable("Step", 0, typeof(IntegerVariable));
    }
    public override void OnEnter()
    {
        var currentStep = _step.GetValue() is int ? (int) _step.GetValue() : 0;
        if (currentStep > 0)
            base.Continue(currentStep);
        else 
            base.Continue(CommandIndex + 1);
    }
}