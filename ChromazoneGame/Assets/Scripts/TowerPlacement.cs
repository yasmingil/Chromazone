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
            PlaceTower(tower1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlaceTower(tower2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlaceTower(tower3);
        }
    }

    private void PlaceTower(GameObject tower)
    { 
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        float closestDist = float.MaxValue;
        foreach (var t in towers)
        {
            if (Vector3.Distance(t.transform.position, transform.position) <= closestDist)
            {
                
            }
        }
    }
}