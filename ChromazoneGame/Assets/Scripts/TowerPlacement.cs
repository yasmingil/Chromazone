using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    [SerializeField] private float placementRadius;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }
    }

    private void PlaceTower(GameObject tower)
    { 
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (var t in towers)
        {
            
        }
    }
}