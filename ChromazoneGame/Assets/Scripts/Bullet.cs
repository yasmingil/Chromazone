using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int BulletDamage;
    [SerializeField] bool isEnemy = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Boundary")
        {
            Destroy(gameObject);
            Debug.Log("Destroy bullet");
        }
        if(isEnemy == true)
        {
            if (collision.transform.tag == "Player")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<PlayerStats>().ChangeHealth(-BulletDamage);
            }
        }
        else
        {
            if(collision.transform.tag == "Enemy")
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<EnemyParent>().ChangeHealth(-BulletDamage);
            }
        }
        
    }

    public void SetBulletDamage(int newDamage)
    {
        BulletDamage = newDamage;
    }

    public void SetIsEnemy(bool newIsEnemy)
    {
        isEnemy = newIsEnemy;
    }
}
