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
    private int frames = 0;
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
        transform.position += ownerToMinTarget * (speed * Time.deltaTime);
        transform.up = -ownerToMinTarget * (speed * Time.deltaTime);
        
        
    }
    

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Tower")
        {
            Debug.Log("hit a tower");
            c.gameObject.GetComponent<TowerScript>().TakeDamage(towerDamage);
            Destroy(gameObject);
        }

        else if(c.gameObject.tag == "Player")
        {
            // bomb damage if enemy touches player?
            Debug.Log("Player bomb damage");
            c.gameObject.GetComponent<PlayerStats>().ChangeHealth(playerDamage);
            Destroy(gameObject);
        }
        
    }

    public void ChangeHealth(int healthChange)
    {
        health += healthChange;
        //if(health == 0f)
        //JUST TO TEST: if collide with player bullet, drop items
        if (health <= 0)
        {
            Debug.Log("Enemy Killed, may drop shit");
            
            //drops healthItem of healthDrop value
            int chanceHealth = Random.Range(1,100);
            int chanceGold = Random.Range(1,100);
            if(chanceHealth <= healthDropRate)
            {
                GameObject spawnHealthItem = Instantiate(healthItem, transform.position, Quaternion.identity);
            }
            
            else if(chanceGold <= goldDropRate)
            {
                GameObject spawnHealthItem = Instantiate(goldItem, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            GameObject.FindObjectOfType<AudioManager>().EnemyDie();
        }
    }

}
