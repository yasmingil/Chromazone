using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    //drop rates already in xx%
    [SerializeField] private int goldDropRate;
    [SerializeField] private int healthDropRate;
    [SerializeField] private int goldDropValue;
    [SerializeField] private int healthDropValue;
    [SerializeField] private int health = 100;
    [SerializeField] private float speed;
    [SerializeField] private int towerDamage;
    [SerializeField] private int playerDamage;
    [SerializeField] private GameObject healthItem;
    [SerializeField] private GameObject goldItem;

    [SerializeField] private GameObject target;

    [SerializeField] private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
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
        if (c.gameObject.tag == "Tower")
        {
            Debug.Log("hit a tower");
            speed = 0f;
        }

        else if(c.gameObject.tag == "Player")
        {
            // bomb damage if enemy touches player?
            Debug.Log("Player bomb damage");
            c.gameObject.GetComponent<PlayerStats>().ChangeHealth(playerDamage);
        }
        //JUST TO TEST: if collide with player bullet, drop items
        if (c.gameObject.tag == "PlayerBullet")
        {
            //drops healthItem of healthDrop value
            int chanceHealth = Random.Range(1,100);
            int chanceGold = Random.Range(1,100);
            if(chanceHealth >= healthDropRate)
            {
                GameObject spawnHealthItem = Instantiate(healthItem, transform.position, Quaternion.identity);
            }
            
            else if(chanceGold >= healthDropRate)
            {
                GameObject spawnHealthItem = Instantiate(goldItem, transform.position, Quaternion.identity);
            }
        }
    }

    public void ChangeHealth(int healthChange)
    {
        health += healthChange;
        //if(health == 0f)
        
    }

}
