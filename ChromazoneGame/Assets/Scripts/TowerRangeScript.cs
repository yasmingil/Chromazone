using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float radius = GetComponent<TowerScript>().GetRadius();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
