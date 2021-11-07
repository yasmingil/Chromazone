using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [SerializeField] private Transform playArea;
    [SerializeField] private LayerMask turretRangeLayerMask;
    [SerializeField] private TMP_Text waveDisplay;

    [SerializeField] private List<Wave> waves;

    private Wave currentWave;
    private int currentWaveIndex;
    private float waveTimer = 0;
    private float spawnTimer = 0;
    private float percentCovered;

    void Start()
    {
        currentWaveIndex = 0;
        currentWave = waves[currentWaveIndex];

        waveDisplay.text = "Wave: 1";

        // StartCoroutine(UpdateFillPercent());
    }

    void Update()
    {
        waveTimer += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        CheckSpawning();
        CheckWaveChange();
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
            Debug.Log("WAVE CHANGED");
            currentWaveIndex++;
            if (currentWaveIndex < waves.Count)
            {
                currentWave = waves[currentWaveIndex];
            }
            Debug.Log(currentWave.enemiesPerSecond);
            waveTimer = 0;
            waveDisplay.text = "Wave: " + (currentWaveIndex + 1);
        }
    }

    public IEnumerator UpdateFillPercent()
    {
        int numRaysHit = 0;

        for (int i = 0; i < 100; i++)
        {
            float rayStartY = ((playArea.localScale.y / 100) * i) - ((playArea.localScale.y / 2) - playArea.position.y);
            for (int j = 0; j < 100; j++)
            {
                float rayStartX = ((playArea.localScale.x / 100) * j) - ((playArea.localScale.x / 2) - playArea.position.x);
                Vector3 rayStartPos = new Vector3(rayStartX, rayStartY, -.5f);
                if (Physics.Raycast(rayStartPos, Vector3.forward, 1f, turretRangeLayerMask, QueryTriggerInteraction.Collide))
                {
                    numRaysHit++;
                }
            }
            yield return new WaitForSeconds(1 / 100f);
        }

        percentCovered = numRaysHit / 100;
        Debug.Log(percentCovered);
        //percentDisplay.text = percentCovered.ToString();
    }

    public float GetCurrentEnemiesPerSecond()
    {
        return currentWave.enemiesPerSecond;
    }
    public void LoseGame()
    {

    }
}
