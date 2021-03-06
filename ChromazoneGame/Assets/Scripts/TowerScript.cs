using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    int Health;
    [SerializeField] private int cost;
    [SerializeField] private float range;
    [SerializeField] private Color towerColor;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int bounces;
    private float counter = 0f;

    private enum ShotType { SPREAD, SINGLE };
    [SerializeField] private ShotType towertype;
    private bool pierce;

    GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        Health = maxHealth;

        //see if the bullet pierces or not
        if(towertype == ShotType.SPREAD)
        {
            pierce = true;
        }
        else
        {
            pierce = false;
        }


        //set size of range and tower hp indicator
        GetComponentsInChildren<Transform>()[1].localScale *= range;
        GetComponentsInChildren<Transform>()[2].localScale *= range;
        // transfer color of tower to range
        // GetComponentsInChildren<SpriteRenderer>()[1].color = GetComponentsInChildren<SpriteRenderer>()[0].color;


    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDist = 199999999;
        if (enemies.Length > 0)
        {
            foreach (var g in enemies)
            {
                float distance = Vector3.Distance(transform.position, g.transform.position);

                if (distance < range && distance < closestDist)
                {
                    closestEnemy = g;
                    closestDist = distance;
                }
            }
            GameObject gun = GetComponentsInChildren<Transform>()[4].gameObject;
            Debug.Log("name" + gun.name);
            if (closestEnemy != null)
            {
                gun.transform.up = gun.transform.position - closestEnemy.transform.position;
            }

        }





        //make circle more transparent based on health
        Color temp = GetComponentsInChildren<SpriteRenderer>()[1].color;
        temp.a = (float)Health / (float)maxHealth;
        GetComponentsInChildren<SpriteRenderer>()[1].color = temp;

        //make towerhealthindi be proportional to health
        GameObject canvas = gameObject.transform.GetChild(1).gameObject;
        GameObject HPBar = canvas.transform.GetChild(0).gameObject;
        HPBar.GetComponent<Image>().fillAmount = (float)Health / (float)maxHealth;

        //set the bullet speed and damage
        if (counter <= bulletCooldown || closestEnemy == null)
        {
            counter += Time.deltaTime;
        }
        else
        {

            counter = 0;


            /*
            float angle = Vector3.Angle(transform.position, closestEnemy.transform.position);
            GameObject gun = canvas.transform.GetChild(2).gameObject;
            Vector3 guntemp = gun.transform.localEulerAngles;
            guntemp.z = guntemp.z + angle;
            gun.transform.localEulerAngles = guntemp; */



            GameObject spawnBullet = Instantiate(Bullet, transform.position, Quaternion.identity);
            spawnBullet.GetComponent<towerBulletScript>().SetDamage(damage);
            spawnBullet.GetComponent<towerBulletScript>().SetBulletSpeed(bulletSpeed);
            spawnBullet.GetComponent<towerBulletScript>().SetTarget(closestEnemy);
            spawnBullet.GetComponent<towerBulletScript>().SetPierce(pierce);
            spawnBullet.GetComponent<towerBulletScript>().SetBounce(bounces);
        }
        
       
    }

    public void TakeDamage(int d)
    {
        Health -= d;
        Debug.Log("take dmg " + Health);
        if (Health <= 0)
        {
            GameObject.FindObjectOfType<AudioManager>().RemoveTowerLayer();
            Debug.Log("die");
            if(gameObject.name == "CORE")
            {
                gameManager.GetComponent<GameManager>().LoseGame();
            }
            Destroy(gameObject);


        }
    }

    public void Heal(int h)
    {
        Health += h;
    }

    public float GetRadius()
    {
        return range;
    }
    public int GetCost()
    {
        return cost;
    }
}
