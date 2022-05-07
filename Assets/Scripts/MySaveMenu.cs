using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class MySaveMenu : MonoBehaviour
{
    [SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;
    [SerializeField] protected bool loadOnStart = true;

    SaveManager saveManager;
    private Variable _step;
    private string StartSaveKeyPoint = string.Empty;
    protected static bool hasLoadedOnStart = false;
   
    protected virtual void Awake()
    {
        saveManager = FungusManager.Instance.SaveManager;
        _step = FungusManager.Instance.GlobalVariables.GetOrAddVariable("Step", 0, typeof(IntegerVariable));
    }

    private void Start()
    {
        if (string.IsNullOrEmpty(saveManager.StartScene))
        {
            saveManager.StartScene = SceneManager.GetActiveScene().name;
        }

        if (loadOnStart && !hasLoadedOnStart)
        {
            hasLoadedOnStart = true;

            if (saveManager.SaveDataExists(saveDataKey))
            {
                saveManager.Load(saveDataKey);
            }
        }
    }

    protected virtual void OnEnable()
    {
        SaveManagerSignals.OnSavePointAdded += OnSavePointAdded;
        BlockSignals.OnCommandExecute += BlockSignals_OnCommandExecute;
        SaveManagerSignals.OnSavePointLoaded += SaveManagerSignals_OnSavePointLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected virtual void OnDisable()
    {
        SaveManagerSignals.OnSavePointAdded -= OnSavePointAdded;
        BlockSignals.OnCommandExecute -= BlockSignals_OnCommandExecute;
        SaveManagerSignals.OnSavePointLoaded -= SaveManagerSignals_OnSavePointLoaded;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        //_step.Apply(SetOperator.Assign, 0);
    }
    
    private void SaveManagerSignals_OnSavePointLoaded(string savepointkey)
    {
        StartSaveKeyPoint = savepointkey;
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
        if (command is Say)
        {
            _step.Apply(SetOperator.Assign, commandIndex);
            saveManager.AddSavePoint(StartSaveKeyPoint, "Auto Save");
            Debug.Log("AutoSave is done: " + commandIndex); //
        } else if (command is SavePoint)
        {
            StartSaveKeyPoint = ((SavePoint) command).SavePointKey;
        }
    }
    
    
}
