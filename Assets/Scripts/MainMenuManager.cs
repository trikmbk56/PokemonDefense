using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public void clickStart()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void clickHelp()
    {
        SceneManager.LoadScene("HelpScene");
    }

    public void clickHighScore()
    {
        SceneManager.LoadScene("HighScoreScene");
    }
}
