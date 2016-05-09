using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {
    public List<Text> name;
    public List<Text> highScore;
    private int maxNumberHighScore = 5;

    public void clickBack()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    void Start()
    {
        for (int i = 0; i < maxNumberHighScore; i++)
        {
            name[i].text = PlayerPrefs.GetString("Name" + i, "Not Have");
            highScore[i].text = PlayerPrefs.GetInt("HighScore" + i, 0).ToString();
        }
    }
}
