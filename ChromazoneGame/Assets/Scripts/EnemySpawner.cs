using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform playArea;
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private GameObject testingTower;
    [SerializeField] private float testingRadius;

    private float timer;

    public void SpawnEnemy(GameObject enemy)
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        Vector3 spawnPosition = new Vector3();

        bool validPlace = false;
        while (!validPlace)
        {
            //spawn on top or bottom
            if (Random.Range(0, 2) == 0)
            {
                //spawn on top
                if (Random.Range(0, 2) == 0)
                {
                    spawnPosition = new Vector3(Random.Range(-playArea.localScale.x / 2, playArea.localScale.x / 2), playArea.localScale.y / 2, 0);
                }
                //spawn on bottom
                else
                {
                    spawnPosition = new Vector3(Random.Range(-playArea.localScale.x / 2, playArea.localScale.x / 2), -playArea.localScale.y / 2, 0);
                }
            }
            //spawn on left or right
            else
            {
                //spawn on left
                if (Random.Range(0, 2) == 0)
                {
                    spawnPosition = new Vector3(-playArea.localScale.x / 2, Random.Range(-playArea.localScale.y / 2, playArea.localScale.y / 2), 0);
                }
                //spawn on right
                else
                {
                    spawnPosition = new Vector3(playArea.localScale.x / 2, Random.Range(-playArea.localScale.y / 2, playArea.localScale.y / 2), 0);
                }
            }
            spawnPosition += playArea.transform.position;

            validPlace = true;
            foreach (GameObject tower in towers)
            {
                //if (tower.GetComponent<TowerScript>().GetRadius())

                if (Vector3.Distance(spawnPosition, tower.transform.position) < testingRadius)
                {
                    validPlace = false;
                }
            }
        }
        
        Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
