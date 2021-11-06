using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] private float goldDrop;
    [SerializeField] private float healthDrop;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float towerDamage;
    [SerializeField] private float playerDamage;

    [SerializeField] private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
