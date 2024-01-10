using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    private List<GameObject> enemiesList = new List<GameObject>();

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
            //you win
            Debug.Log("win");
        }
    }

    public void KilledEnemy(GameObject enemy)
    {
        if(enemiesList.Contains(enemy)) enemiesList.Remove(enemy);
    }


}
