using Fungus;

[CommandInfo("Flow", "Auto Save Load Point", "Set Auto Save Point")]
public class AutoSavePoint : SavePoint
{
    private IntegerVariable _step;
    private StringVariable _name;

    private int _tmp;
    
    private void Awake()
    {
        _step = (IntegerVariable) FungusManager.Instance.GlobalVariables.GetOrAddVariable("BlockStep", 0, typeof(IntegerVariable));
        _name  = (StringVariable) FungusManager.Instance.GlobalVariables.GetOrAddVariable("BlockName", "", typeof(StringVariable));
    }

    public override int CommandIndex { 
        #if UNITY_EDITOR
        get => _tmp;
        #else
        get=>(int)_step.GetValue();
        #endif
        set => _tmp = value;
    }
        
    public override void OnEnter()
    {
        var currentStep = _step.GetValue() is int ? (int) _step.GetValue() : 0;
        var currentName = this.ParentBlock.BlockName;
        if (fireEvent)
        {
            SavePointLoaded.NotifyEventHandlers(SavePointKey);
        }
        if (currentStep > 0 && currentName.Equals(_name.Value))
            base.Continue(currentStep-1);
        else 
            base.Continue(1); //Команда должна быть всегда 1 в списке. 
        
    }
}