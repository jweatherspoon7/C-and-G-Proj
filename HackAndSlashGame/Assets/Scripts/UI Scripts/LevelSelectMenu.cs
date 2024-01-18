using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : MonoBehaviour
{
    public GameObject mainMenu;
    private const int CITY_LEVEL_INDEX = 1;

    public void OnEnable()
    {
        mainMenu.SetActive(false);
    }

    public void CityLevelButton()
    {
        SceneManager.LoadScene(CITY_LEVEL_INDEX);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
    }
}
