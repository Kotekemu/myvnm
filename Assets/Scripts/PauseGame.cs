using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool GameIsPaused = false;

    void FixedUpdate()
    {

    if (GameIsPaused)
        {
            Resume();
        }
    else
        {
            Pause();
        }
        
    }
    public void Resume()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
    }
}
