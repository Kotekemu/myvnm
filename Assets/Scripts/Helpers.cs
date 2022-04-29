using Fungus;
using UnityEngine;

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
    public void DeleteHistory()
    {
        SaveManager.Delete("save_data");
    }
}
