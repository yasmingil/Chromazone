using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class towerBulletScript : MonoBehaviour
{
    private int damage;
    private float bulletSpeed;
    private GameObject target = null;
    private float rotateSpeed = 1000f;
    private bool pierce;
    private int bounceCounter=0;
    private int bounces;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector2 direction = (Vector2)target.transform.position - rb.position;

        direction.Normalize();

        float rotateAmmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmmount * rotateSpeed;

        rb.velocity = direction * bulletSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;

            direction.Normalize();

            float rotateAmmount = Vector3.Cross(direction, transform.up).z;

            rb.velocity = direction * bulletSpeed;
        }
        else
        {

        }

    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.CompareTag("Enemy"))
        {
            if (!pierce)
            {
                Destroy(gameObject);
            }

            bounceCounter++;
            target = newTarget(target);
            if(target == null || bounceCounter==bounces)
            {
                Destroy(gameObject);
            }



        }
        else if (collision.tag == "Border")
        {
            Destroy(gameObject);

        }
    }

    private GameObject newTarget(GameObject t)
    {
        //same thing as find closest in range but take out all the range part
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDist = 199999999;
        if (enemies.Length > 0)
        {
            foreach (var g in enemies)
            {
                float distance = Vector3.Distance(transform.position, g.transform.position);

                if (g != target && distance < closestDist)
                {
                    closestEnemy = g;
                    closestDist = distance;
                }
            }
            return closestEnemy;
        }
        return null;

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
    public void SetPierce(bool p)
    {
        pierce = p;
    }
    public void SetBounce(int b)
    {
        bounces = b;
    }
}
