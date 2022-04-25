using Fungus;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var saveManager = FungusManager.Instance.SaveManager;
        if (saveManager.SaveDataExists("save_data"))
        {
            saveManager.Load("save_data");
        }
    }

}
