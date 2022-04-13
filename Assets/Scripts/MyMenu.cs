using Fungus;
using UnityEngine;

/// <summary>
/// A singleton game object which displays a simple UI for the save system.
/// </summary>
public class MyMenu : MonoBehaviour
{
    [Tooltip("The string key used to store save game data in Player Prefs. If you have multiple games defined in the same Unity project, use a unique key for each one.")]
    [SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;

    /// <summary>
    /// Handler function called when the Save button is pressed.
    /// </summary>
    public virtual void Save()
    {
        var saveManager = FungusManager.Instance.SaveManager;

        if (saveManager.NumSavePoints > 0)
        {
            saveManager.Save(saveDataKey);
        }
    }

    /// <summary>
    /// Handler function called when the Load button is pressed.
    /// </summary>
    public virtual void Load()
    {
        var saveManager = FungusManager.Instance.SaveManager;

        if (saveManager.SaveDataExists(saveDataKey))
        {
            saveManager.Load(saveDataKey);
        }

    }
}
