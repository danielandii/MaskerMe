using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    
    void OnApplicationFocus(bool hasFocus)
    {
         Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

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

    public void GotoTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }
}