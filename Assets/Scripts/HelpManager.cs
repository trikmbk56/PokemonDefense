using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HelpManager : MonoBehaviour {
    public void clickStart()
    {
        SceneManager.LoadScene("OptionScene");
    }

    public void clickMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
