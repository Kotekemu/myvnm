using Fungus;
using UnityEngine;

public class MyMenu : MonoBehaviour
{
    [SerializeField] protected string saveDataKey = FungusConstants.DefaultSaveDataKey;

    public virtual void Save()
    {
        var saveManager = FungusManager.Instance.SaveManager;

        if (saveManager.NumSavePoints > 0)
        {
            saveManager.Save(saveDataKey);
        }
    }

    public virtual void Load()
    {
        var saveManager = FungusManager.Instance.SaveManager;

        if (saveManager.SaveDataExists(saveDataKey))
        {
            saveManager.Load(saveDataKey);
        }

    }
}
