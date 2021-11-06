using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private float range;
    [SerializeField] private Color towerColor;
    [SerializeField] private float attackSpeed;
    [SerializeField] private int dammage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private enum shotType { SPREAD, SINGLE }; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy;
        float closestDist;
        foreach(var g in enemies)
        {
            float distance = Vector3.Distance(transform.position, g.transform.position);
            if (distance <= range)
            {

            }

        }
    }
}
