using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    [SerializeField] private int Health;
    [SerializeField] private float range;
    [SerializeField] private Color towerColor;
    [SerializeField] private float attackSpeed;
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
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy=null;
        float closestDist = 199999999;
        foreach(var g in enemies)
        {
            float distance = Vector3.Distance(transform.position, g.transform.position);

            if (distance < range && distance < closestDist )
            {
                closestEnemy = g;
            }
        }

        GameObject spawnBullet = Instantiate(bullet, transform.position, Quaternion.identity);

        //set the bullet speed and damage
        spawnBullet.SetDamage(damage);
        spawnBullet.SetbulletSpeed(bulletSpeed);
        spawnBullet.SetTarget(closestEnemy);
    }

    public float GetRadius()
    {
        return range;
    }
}
