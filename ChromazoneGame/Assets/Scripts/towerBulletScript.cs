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
        Vector2 direction = (Vector2)target.transform.position - rb.position;

        direction.Normalize();

        float rotateAmmount = Vector3.Cross(direction, transform.up).z;


        rb.velocity = direction * bulletSpeed;  

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
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
