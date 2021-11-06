using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D playArea;
    [SerializeField] private GameObject enemyPrefab;

    public void SpawnEnemy()
    {
        Vector3 spawnPosition;
        //spawn on top or bottom
        if (Random.Range(0, 1) == 0)
        {
            //spawn on top
            if (Random.Range(0, 1) == 0)
            {
                spawnPosition = new Vector3(Random.Range(-playArea.size.x, playArea.size.x), playArea.size.y / 2, 0);
            }
            //spawn on bottom
            else
            {
                spawnPosition = new Vector3(Random.Range(-playArea.size.x / 2, playArea.size.x / 2), -playArea.size.y / 2, 0);
            }
        }
        //spawn on left or right
        else
        {
            //spawn on left
            if (Random.Range(0, 1) == 0)
            {
                spawnPosition = new Vector3(-playArea.size.x / 2, Random.Range(-playArea.size.y / 2, playArea.size.y / 2), 0);
            }
            //spawn on right
            else
            {
                spawnPosition = new Vector3(playArea.size.x / 2, Random.Range(-playArea.size.y / 2, playArea.size.y / 2), 0);
            }
        }

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
