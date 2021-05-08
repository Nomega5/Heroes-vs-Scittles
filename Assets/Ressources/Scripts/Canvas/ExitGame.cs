using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public GameObject exitPanel;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "PersonnageSystem")
        {
            exitPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        exitPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        PlayerPrefs.SetInt("GameCoinsAmount", 0);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
