using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PokemonLevel
{
    public int cost;
    public GameObject visualization;
    public GameObject bullet;
    public float fireRate;
}

public class PokemonData : MonoBehaviour {
    public List<PokemonLevel> levels;
    private PokemonLevel currentLevel;

    public PokemonLevel CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            int currentLevelIndex = levels.IndexOf(value);
            if (currentLevelIndex != -1)
            {
                currentLevel = value;
                for (int i = 0; i < levels.Count; i++)
                {
                    if (i == currentLevelIndex)
                        levels[i].visualization.SetActive(true);
                    else
                        levels[i].visualization.SetActive(false);
                }
            }
        }
    }

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public PokemonLevel getNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(CurrentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void increaseLevel()
    {
        PokemonLevel nextLevel = getNextLevel();
        if (nextLevel != null)
            CurrentLevel = nextLevel;
    }
}
