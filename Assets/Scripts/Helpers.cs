using System;
using Fungus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helpers : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void AboutUs()
    {
        Application.OpenURL("https://vk.com/1rgt1"); 
    }

    public void Continue()
    {
        FungusManager.Instance.SaveManager.Load("save_data");
    }
    
    public void DeleteHistory()
    {
        if (FungusManager.Instance.SaveManager.SaveDataExists("save_data"))
        {
            try
            {
                SaveManager.Delete("save_data");
            }
            catch (Exception)
            {
                // ignored
            }
        }
        FungusManager.Instance.SaveManager.ClearHistory();
        var _step = FungusManager.Instance.GlobalVariables.GetOrAddVariable("BlockStep", 0, typeof(IntegerVariable));
        _step.Apply(SetOperator.Assign, 0);
    }

    public void LoadAbout()
    {
        SceneManager.LoadScene("About");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
}
