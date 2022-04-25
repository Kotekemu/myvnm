using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class MySaveMenu : MonoBehaviour
{
    [SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;

    [SerializeField] protected bool loadOnStart = true;

    [SerializeField] protected bool autoSave = false;

    [SerializeField] protected bool restartDeletesSave = false;

    [SerializeField] protected Button saveButton;

    SaveManager saveManager;


    protected static bool saveMenuActive = false;

    // protected LTDescr fadeTween;

    // protected static MySaveMenu instance;

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

    protected virtual void Start()
    {


        // Make a note of the current scene. This will be used when restarting the game.
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

    protected virtual void Update()
    {

        // Hide the Save and Load buttons if autosave is on

        bool showSaveAndLoad = !autoSave;
        if (saveButton != null)
        {
            if (saveButton.IsActive() != showSaveAndLoad)
            {
                saveButton.gameObject.SetActive(showSaveAndLoad);

            }
        }

        if (showSaveAndLoad)
        {
            if (saveButton != null)
            {
                saveButton.interactable = saveManager.NumSavePoints > 0 && saveMenuActive;
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

        if (autoSave &&
            saveManager.NumSavePoints > 0)
        {
            saveManager.Save(saveDataKey);
            Debug.Log("AutoSave is done");
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
