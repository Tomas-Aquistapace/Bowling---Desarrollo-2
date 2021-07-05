using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Scenes Names")]
    public string classic;
    public string shooter;

    public void PlayClassicGame()
    {
        SceneManager.LoadScene(classic);
    }

    public void PlayShooterGame()
    {
        SceneManager.LoadScene(shooter);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
