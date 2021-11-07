using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private List<AudioSource> towerSources;
    [SerializeField] private AudioSource intensitySource;
    [SerializeField] private float fadeTime;
    [SerializeField] private float minEnemiesPerSecond;
    [SerializeField] private float maxEnemiesPerSecond;

    private int numTowers;
    private float startingTowerVolume;
    private float startingIntensityVolume;

    [Header("SFX")]
    [SerializeField] private AudioSource effectSource;

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

        if (numTowers <= towerSources.Count)
        {
            StartCoroutine(FadeIn(towerSources[numTowers], fadeTime, startingTowerVolume));
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

        intensitySource.volume = startingIntensityVolume * enemiesPerSecondPercent;
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
}
