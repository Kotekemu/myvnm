using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }
    public void AboutUs()
    {
        Application.OpenURL("https://vk.com/1rgt1"); 
    }
}
