using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject Menu;

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
        //gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        //gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
    }
}
