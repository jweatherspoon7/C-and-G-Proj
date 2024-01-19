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

    public string targetTag = "Enemy";

    private GameObject endText;
    private bool showScreen = false;

    // Start is called before the first frame update
    void Start()
    {
        enemiesList.AddRange(GameObject.FindGameObjectsWithTag(targetTag));
    }

    // Update is called once per frame
    void Update()
    {
        if (showScreen)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            endScreen.SetActive(true);
            endText.SetActive(true);
        }
    }

    public void KilledEnemy(GameObject enemy)
    {
        if(enemiesList.Contains(enemy)) enemiesList.Remove(enemy);

        if (enemiesList.Count == 0)
        {
            Debug.Log("win");

            endText = winText;

            StartCoroutine(TimeToEndScreen(3));
        }
    }

    public void PlayerDeath()
    {
        Debug.Log("lose");

        endText = deathText;

        StartCoroutine(TimeToEndScreen(3));
    }

    IEnumerator TimeToEndScreen(float time)
    {
        yield return new WaitForSeconds(time);
        showScreen = true;
    }
}
