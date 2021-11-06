using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private enum shotType { SPREAD, SINGLE };
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO:
        // Get list of gameobjects that are towers and player. 
        // take priority of which one is closer, so if player is out of certain range,
        // the gunner will focus bullets on tower

        // TODO:
        // limit range on gunners? (not shooting from across the map)
    }
}
