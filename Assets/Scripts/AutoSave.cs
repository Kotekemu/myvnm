using Fungus;
using UnityEngine;

public class AutoSave : MonoBehaviour
{

    private SaveManager saveManager;
    private void Awake()
    {
        saveManager = FungusManager.Instance.SaveManager;
    }


    protected virtual void OnEnable()
    {
        SaveManagerSignals.OnSavePointAdded += OnSavePointAdded;
    }

    protected virtual void OnDisable()
    {
        SaveManagerSignals.OnSavePointAdded -= OnSavePointAdded;
    }

    protected virtual void OnSavePointAdded(string savePointKey, string savePointDescription)
    {
        saveManager.Save("save_data");
    }
}
