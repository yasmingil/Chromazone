using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerBulletScript : MonoBehaviour
{
    public int damage;
    public float bulletSpeed;
    public GameObject target=null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        Vector3 targetPos = target.transform.position;
        Vector3 direction = targetPos - transform.position;
        direction.z = 0;
        direction.Normalize();
        Vector3 bulletVelocity = direction * bulletSpeed;
    }
    public void SetDamage(int d)
    {
        damage = d;
    }
    public void SetBulletSpeed(float s)
    {
        bulletSpeed = s;
    }
    public void SetTarget(GameObject e)
    {
        target = e;
    }
}
