using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject[] objectsToActivate;

    public Canvas canvas;
    public GameObject howToScreen;

    public void OnEnable()
    {
        howToScreen.SetActive(false);
    }

    //use to remove canvas and to active gameObjects for the game
    public void PlayGame()
   {
        for(int i = 0; i< objectsToActivate.Length;i++)
        {
            objectsToActivate[i].SetActive(true);
        }

        //remove canvas when clicked
        canvas.enabled = false;
   }

    public void HowTo()
    {
        howToScreen.SetActive(true);
    }
}
