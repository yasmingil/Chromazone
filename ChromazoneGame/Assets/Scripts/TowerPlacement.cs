using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    private GameObject currentSelected;
    [SerializeField] private float placementRadius;
    [SerializeField] private Image radiusUI;
    [SerializeField] private Image placementUI;
    private enum currentState
    {
        SHOOTING,
        PLACING,
        PAUSED
    };
    
    private void Start()
    {
        radiusUI.enabled = false;
        placementUI.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSelected = tower1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSelected = tower2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSelected = tower3;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
        }

    }

    private void PlaceTower(GameObject tower)
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        float closestDist = float.MaxValue;
        foreach (var t in towers)
        {
            if (Vector3.Distance(t.transform.position, transform.position) <= closestDist)
            {
                
            }
        }

        GameObject.FindObjectOfType<AudioManager>().AddTowerLayer();
    }
}