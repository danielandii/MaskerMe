using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void GotoNorePlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GotoNoreMenu()
    {
        SceneManager.LoadScene("NoreMenu");
    }

    public void GotoNoreGameOver()
    {
        SceneManager.LoadScene("NoreGameOver");
    }
}