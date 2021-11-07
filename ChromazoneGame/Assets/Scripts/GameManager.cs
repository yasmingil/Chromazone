using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public float timeInSeconds;
        public float enemiesPerSecond;
        [Range(0, 100)]
        public float percentEnemiesGunners;
    }

    [SerializeField] private GameObject bomberPrefab;
    [SerializeField] private GameObject gunnerPrefab;

    [SerializeField] private List<Wave> waves;

    private Wave currentWave;
    private int currentWaveIndex;
    private float waveTimer = 0;
    private float spawnTimer = 0;

    void Start()
    {
        currentWaveIndex = 0;
        currentWave = waves[currentWaveIndex];
    }

    void Update()
    {
        waveTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        CheckSpawning();
        CheckWaveChange();

        UpdateFillPercent();
    }

    private void CheckSpawning()
    {
        if (spawnTimer >= 1 / currentWave.enemiesPerSecond)
        {
            if (Random.Range(0f, 100f) < currentWave.percentEnemiesGunners)
            {
                GetComponent<EnemySpawner>().SpawnEnemy(gunnerPrefab);
            }
            else
            {
                GetComponent<EnemySpawner>().SpawnEnemy(bomberPrefab);
            }
            spawnTimer = 0;
        }
    }

    private void CheckWaveChange()
    {
        if (waveTimer >= currentWave.timeInSeconds)
        {
            currentWaveIndex++;
            currentWave = waves[currentWaveIndex];

            waveTimer = 0;
        }
    }

    private void UpdateFillPercent()
    {

    }
}
