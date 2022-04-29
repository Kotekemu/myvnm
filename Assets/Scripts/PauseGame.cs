using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject Menu;


    private void Start()
    {
        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        if (Menu.activeSelf){
            Pause();
        } else
        {
            Resume();
        }

    }
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    void Pause()
    {
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
    }
}
