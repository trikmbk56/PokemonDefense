using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour {
    public Toggle map1, map2, map3;
    public Dropdown dropdown;

    public void chooseMap1()
    {
        map1.isOn = true;
        map2.isOn = false;
        map3.isOn = false;
    }

    public void chooseMap2()
    {
        map1.isOn = false;
        map2.isOn = true;
        map3.isOn = false;
    }

    public void chooseMap3()
    {
        map1.isOn = false;
        map2.isOn = false;
        map3.isOn = true;
    }

    public void clickStart()
    {
        if (map1.isOn)
            SceneManager.LoadScene("Map1Scene");
        else if (map2.isOn)
            SceneManager.LoadScene("Map2Scene");
        else
            SceneManager.LoadScene("Map3Scene");
    }

    public void changeDropdown()
    {
        PlayerPrefs.SetInt("Level", dropdown.value);
    }

    void Start()
    {
        PlayerPrefs.SetInt("Level", dropdown.value);
    }
}
