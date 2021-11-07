using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioSource> towerSources;
    [SerializeField] private AudioSource intensitySource;
    [SerializeField] private float fadeTime;
    [SerializeField] private float minEnemiesPerSecond;
    [SerializeField] private float maxEnemiesPerSecond;

    private int numTowers;
    private float startingTowerVolume;
    private float startingIntensityVolume;

    //TODO finish implementing tower intensity

    private void Start()
    {
        startingTowerVolume = towerSources[0].volume;

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
            StartCoroutine(FadeIn(towerSources[numTowers], fadeTime));
        }
    }

    public void RemoveTowerLayer()
    {
        if (numTowers <= towerSources.Count)
        {
            StartCoroutine(FadeOut(towerSources[numTowers], fadeTime));
        }

        numTowers--;
    }

    private void UpdateIntensityTrack()
    {

    }

    private IEnumerator FadeIn(AudioSource source, float time)
    {
        bool finished = false;
        while (!finished)
        {
            source.volume += startingTowerVolume * 0.01f * (1 / time);
            if (source.volume >= startingTowerVolume)
            {
                source.volume = startingTowerVolume;
                finished = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeOut(AudioSource source, float time)
    {
        bool finished = false;
        while (!finished)
        {
            source.volume -= startingTowerVolume * 0.01f * (1 / time);
            if (source.volume <= 0)
            {
                source.volume = 0;
                finished = true;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
