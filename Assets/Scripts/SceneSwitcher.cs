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
        if(PlayerPrefs.HasKey("firstTIme")){
            SceneManager.LoadScene("MainScene");
        } else {
            SceneManager.LoadScene("FirstTutorialScene");
            PlayerPrefs.SetInt("firstTIme", 1);
        }
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

    public void exitGame()
    {
        Application.Quit();
    } 
}