using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu: MonoBehaviour
{
    public Canvas canvas;
    public GameObject howToScreen;
    public GameObject levelSelectScreen;

    public void OnEnable()
    {
        howToScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
    }

    //use to remove canvas and to active gameObjects for the game
    public void PlayGame()
   {
        levelSelectScreen.SetActive(true);
   }

    public void HowTo()
    {
        howToScreen.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
