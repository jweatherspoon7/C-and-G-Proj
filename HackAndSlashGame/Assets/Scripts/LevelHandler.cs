using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    private List<GameObject> enemiesList = new List<GameObject>();
    public GameObject endScreen;
    public GameObject winText;
    public GameObject deathText;

    // Start is called before the first frame update
    void Start()
    {
        enemiesList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesList.Count == 0)
        {
            Debug.Log("win");
        }
    }

    public void KilledEnemy(GameObject enemy)
    {
        if(enemiesList.Contains(enemy)) enemiesList.Remove(enemy);

        if (enemiesList.Count == 0)
        {
            Debug.Log("win");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            endScreen.SetActive(true);
            winText.SetActive(true);
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("lose");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        endScreen.SetActive(true);
        deathText.SetActive(true);
    }
}
