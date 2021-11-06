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

    [SerializeField] private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        float min = 10000000000;
        GameObject minTower = null;
        foreach (GameObject tower in towers)
        {
            Vector3 targetPos = tower.transform.position;
            Vector3 ownerPos = transform.position;
            Vector3 ownerToTarget = targetPos - ownerPos;
            float distance = ownerToTarget.magnitude;
            if(distance < min)
            {
                min = distance;
                minTower = tower;
            }
        }
        Vector3 ownerToMinTarget = (minTower.transform.position - transform.position);
        ownerToMinTarget.Normalize();
        transform.position += ownerToMinTarget * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "tower")
        {
            Debug.Log("hit a tower");
            speed = 0f;
        }
    }
}
