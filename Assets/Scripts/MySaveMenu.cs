using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;

public class MySaveMenu : MonoBehaviour
{
    [SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;

    [SerializeField] protected bool loadOnStart = true;

    SaveManager saveManager;

    protected static bool hasLoadedOnStart = false;

    protected virtual void Awake()
    {
        saveManager = FungusManager.Instance.SaveManager;
        /*
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        if (transform.parent == null)
        {
            GameObject.DontDestroyOnLoad(this);
        }
        else
        {
            Debug.LogError("Save Menu cannot be preserved across scene loads if it is a child of another GameObject.");
        }
        */

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
    }

    private void BlockSignals_OnCommandExecute(Block block, Command command, int commandIndex, int maxCommandIndex)
    {
        if (command is Say)
        {
            // saveManager.AddSavePoint(saveDataKey, ""); //
            // Debug.Log("AutoSave is done"); //
        }
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

    public virtual string SaveDataKey { get { return saveDataKey; } }

    public virtual void Save()
    {

        if (saveManager.NumSavePoints > 0)
        {
            saveManager.Save(saveDataKey);
        }
    }
}
