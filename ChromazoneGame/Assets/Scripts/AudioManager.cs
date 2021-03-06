using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource coreSource;
    [SerializeField] private List<AudioSource> towerSources;
    [SerializeField] private AudioSource intensitySource;
    [SerializeField] private float fadeTime;
    [SerializeField] private float minEnemiesPerSecond;
    [SerializeField] private float maxEnemiesPerSecond;
    [SerializeField] private float fadeDieTime;

    private int numTowers;
    private float startingTowerVolume;
    private float startingIntensityVolume;

    [Header("SFX")]
    [SerializeField] private AudioSource enemyEffectSource;
    [SerializeField] private AudioClip enemyDieSound;

    private void Start()
    {
        startingTowerVolume = towerSources[0].volume;
        startingIntensityVolume = intensitySource.volume;

        foreach (AudioSource s in towerSources)
        {
            s.volume = 0;
        }
    }

    private void Update()
    {
        UpdateIntensityTrack();
    }

    public void AddTowerLayer()
    {
        numTowers++;

        if (numTowers < towerSources.Count)
        {
            StartCoroutine(FadeIn(towerSources[numTowers - 1], fadeTime, startingTowerVolume));
        }
    }

    public void RemoveTowerLayer()
    {
        if (numTowers <= towerSources.Count)
        {
            StartCoroutine(FadeOut(towerSources[numTowers], fadeTime, startingTowerVolume));
        }

        numTowers--;
    }

    private void UpdateIntensityTrack()
    {
        float enemiesPerSecondRange = maxEnemiesPerSecond - minEnemiesPerSecond;
        float enemiesPerSecondPercent = (GameObject.FindObjectOfType<GameManager>().GetCurrentEnemiesPerSecond() - minEnemiesPerSecond) / enemiesPerSecondRange;

        if (enemiesPerSecondPercent > 1)
        {
            enemiesPerSecondPercent = 1;
        }

        intensitySource.volume = startingIntensityVolume * enemiesPerSecondPercent;
    }

    public void PlayerDie()
    {
        StartCoroutine(FadeDie(coreSource));
        StartCoroutine(FadeDie(intensitySource));

        foreach (AudioSource s in towerSources)
        {
            StartCoroutine(FadeDie(s));
        }
    }

    public void EnemyDie()
    {
        enemyEffectSource.PlayOneShot(enemyDieSound);
    }

    private IEnumerator FadeIn(AudioSource source, float time, float workingVolume)
    {
        bool finished = false;
        while (!finished)
        {
            source.volume += workingVolume * 0.01f * (1 / time);
            if (source.volume >= workingVolume)
            {
                source.volume = workingVolume;
                finished = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeOut(AudioSource source, float time, float workingVolume)
    {
        bool finished = false;
        while (!finished)
        {
            source.volume -= workingVolume * 0.01f * (1 / time);
            if (source.volume <= 0)
            {
                source.volume = 0;
                finished = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeDie(AudioSource source)
    {
        float workingVolume = source.volume;
        float workingPitch = source.pitch;
        bool finished = false;
        while (!finished)
        {
            source.volume -= workingVolume * 0.01f * (1 / fadeDieTime);
            source.pitch -= workingPitch * 0.01f * (1 / fadeDieTime);
            if (source.volume <= 0)
            {
                source.volume = 0;
                finished = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
