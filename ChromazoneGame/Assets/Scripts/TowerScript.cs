using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    int Health;
    [SerializeField] private float range;
    [SerializeField] private Color towerColor;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private enum shotType { SPREAD, SINGLE };
    [SerializeField] private GameObject bullet;
    private float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        GetComponentsInChildren<Transform>()[1].localScale *= range;

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
        }
        //set the bullet speed and damage
        if (counter <= bulletCooldown || closestEnemy==null)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            GameObject spawnBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnBullet.GetComponent<towerBulletScript>().SetDamage(damage);
            spawnBullet.GetComponent<towerBulletScript>().SetBulletSpeed(bulletSpeed);
            spawnBullet.GetComponent<towerBulletScript>().SetTarget(closestEnemy);
        }

        //make circle more transparent based on health
        Color temp = GetComponentsInChildren<SpriteRenderer>()[1].color;
        temp.a = (float)Health*0.5f/(float)maxHealth;
        GetComponentsInChildren<SpriteRenderer>()[1].color = temp;

    }

    public void TakeDamage(int d)
    {
        Health -= d;
    }
    public void Heal(int h)
    {
        Health += h;
    }

    public float GetRadius()
    {
        return range;
    }
}
