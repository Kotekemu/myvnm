using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class MySaveMenu : MonoBehaviour
{
    [SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;

    SaveManager saveManager;
    private Variable _blockStep;
    private Variable _blockName;
   
    protected virtual void Awake()
    {
        saveManager = FungusManager.Instance.SaveManager;
    }

    private void Start()
    {
        _blockStep = FungusManager.Instance.GlobalVariables.GetOrAddVariable("BlockStep", 0, typeof(IntegerVariable));
        _blockName = FungusManager.Instance.GlobalVariables.GetOrAddVariable("BlockName", "", typeof(StringVariable));        
        
        if (string.IsNullOrEmpty(saveManager.StartScene))
        {
            saveManager.StartScene = SceneManager.GetActiveScene().name;
        }
    }

    protected virtual void OnEnable()
    {
        SaveManagerSignals.OnSavePointAdded += OnSavePointAdded;
        BlockSignals.OnCommandExecute += BlockSignals_OnCommandExecute;
    }

    protected virtual void OnDisable()
    {
        SaveManagerSignals.OnSavePointAdded -= OnSavePointAdded;
        BlockSignals.OnCommandExecute -= BlockSignals_OnCommandExecute;
    }
   
    protected virtual void OnSavePointAdded(string savePointKey, string savePointDescription)
    {
        if (saveManager.NumSavePoints > 0)
        {
            saveManager.Save(saveDataKey);
        }
    }

    private void BlockSignals_OnCommandExecute(Block block, Command command, int commandIndex, int maxCommandIndex)
    {
        switch (command)
        {
            case Say _:
                _blockStep.Apply(SetOperator.Assign, commandIndex);
                _blockName.Apply(SetOperator.Assign, block.BlockName);
                saveManager.AddSavePoint(block.BlockName, "Auto Save");
                Debug.Log("AutoSave is done: " + commandIndex + " : " + _blockName); //
                break;
        }
    }
    
    
}
