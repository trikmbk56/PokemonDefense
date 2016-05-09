using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlacePokemon : MonoBehaviour {
    public List<GameObject> pokemonPrefabs;
    private GameObject pokemon;
    private GameManager gameManager;
    private Text warning;

    private bool canPlacePokemon()
    {
        if (gameManager.gameOver || gameManager.pauseGame) return false;
        int cost = pokemonPrefabs[SelectPokemon.selection].GetComponent<PokemonData>().levels[0].cost;
        if (gameManager.gold < cost)
        {
            StartCoroutine(ShowMessage("Not Enough Money!!!", 0.5F));
            return false;
        }
        else
            return pokemon == null;
    }

    private bool canUpgradePokemon()
    {
        if (gameManager.gameOver || gameManager.pauseGame) return false;
        if (pokemon != null)
        {
            PokemonLevel nextLevel = pokemon.GetComponent<PokemonData>().getNextLevel();
            if (nextLevel != null)
            {
                if (gameManager.gold < nextLevel.cost)
                {
                    StartCoroutine(ShowMessage("Not Enough Money!!!", 0.5F));
                    return false;
                }
                else
                    return true;
            }
            else
            {
                StartCoroutine(ShowMessage("Can Not Upgrade!!!", 0.5F));
                return false;
            }
        }
        return false;
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        warning.text = message;
        warning.enabled = true;
        yield return new WaitForSeconds(delay);
        warning.enabled = false;
    }

    void OnMouseUp()
    {
        if (canPlacePokemon())
        {
            // place new pokemon
            pokemon = (GameObject)
                Instantiate(pokemonPrefabs[SelectPokemon.selection], transform.position, Quaternion.identity);

            // play audio source
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            // deduct gold
            deductGold();
        }
        else if (canUpgradePokemon())
        {
            // upgrade pokemon
            pokemon.GetComponent<PokemonData>().increaseLevel();

            // play audio source
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            // deduct gold
            deductGold();
        }
    }

    void deductGold()
    {
        gameManager.Gold -= pokemon.GetComponent<PokemonData>().CurrentLevel.cost;
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        warning = GameObject.Find("Warning").GetComponent<Text>();
        warning.enabled = false;
    }
}
