using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Text healthLabel, goldLabel, scoreLabel, waveLabel;
    public int health, gold, score, wave;
    public bool gameOver = false;
    public bool pauseGame = false;
    public bool started = false;
    public Button readyButton;
    public Canvas pauseCanvas, winCanvas, loseCanvas;
    public GameObject destroyPrefab;

    public void ShowDestroyAnimation(Vector3 position, float delay)
    {
        GameObject destroyAnimation = Instantiate(destroyPrefab);
        destroyAnimation.transform.position = position;
        AudioSource audioSource = destroyAnimation.GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(audioSource.clip, position);
        Destroy(destroyAnimation, delay);
    }

    public void saveHighScore(int highScore)
    {

    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // camera shake
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // update health
            health = value;
            healthLabel.GetComponent<Text>().text = "HEALTH: " + health;
            // game over
            if (health <= 0 && !gameOver)
            {
                // you lose
                gameOver = true;
                Time.timeScale = 0;
                loseCanvas.enabled = true;
            }
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreLabel.GetComponent<Text>().text = "SCORE: " + score;
        }
    }

    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            waveLabel.GetComponent<Text>().text = "WAVE: " + (wave + 1);
        }
    }

    public void clickReady()
    {
        Time.timeScale = 1;
        started = true;
        readyButton.gameObject.SetActive(false);
    }

    public void clickPause()
    {
        Time.timeScale = 0;
        pauseGame = true;
        pauseCanvas.enabled = true;
    }

    public void clickResume()
    {
        if (started) Time.timeScale = 1;
        pauseGame = false;
        pauseCanvas.enabled = false;
    }

    public void clickRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Application.loadedLevelName);
    }

    public void clickMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenuScene");
    }

    public void clickExit()
    {
        Application.Quit();
    }

    void Start()
    {
        Health = 5;
        Gold = 1200;
        Score = 0;
        Wave = 0;
        Time.timeScale = 0;
        pauseCanvas.enabled = false;
        winCanvas.enabled = false;
        loseCanvas.enabled = false;
    }
}
