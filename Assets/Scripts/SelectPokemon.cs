using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectPokemon : MonoBehaviour {
    public Button fpButton, wpButton, gpButton;
    public Text fpText, wpText, gpText;
    public static int selection = 0;

    public void clickFPButton()
    {
        selection = 0;
        Image img = fpButton.GetComponent<Image>();
        img.color = Color.white;
        img = wpButton.GetComponent<Image>();
        img.color = Color.black;
        img = gpButton.GetComponent<Image>();
        img.color = Color.black;
    }

    public void clickWPButton()
    {
        selection = 1;
        Image img = fpButton.GetComponent<Image>();
        img.color = Color.black;
        img = wpButton.GetComponent<Image>();
        img.color = Color.white;
        img = gpButton.GetComponent<Image>();
        img.color = Color.black;
    }

    public void clickGPButton()
    {
        selection = 2;
        Image img = fpButton.GetComponent<Image>();
        img.color = Color.black;
        img = wpButton.GetComponent<Image>();
        img.color = Color.black;
        img = gpButton.GetComponent<Image>();
        img.color = Color.white;
    }

    public void hoverFPButton()
    {
        fpText.enabled = true;
    }

    public void unHoverFPButton()
    {
        fpText.enabled = false;
    }

    public void hoverWPButton()
    {
        wpText.enabled = true;
    }

    public void unHoverWPButton()
    {
        wpText.enabled = false;
    }

    public void hoverGPButton()
    {
        gpText.enabled = true;
    }

    public void unHoverGPButton()
    {
        gpText.enabled = false;
    }

    void Awake()
    {
        fpText.enabled = false;
        wpText.enabled = false;
        gpText.enabled = false;
    }
}
