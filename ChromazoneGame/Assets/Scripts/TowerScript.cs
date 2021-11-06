using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private Color towerColor;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private enum shotType { SPREAD, SINGLE }; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
