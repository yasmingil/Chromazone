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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        if(isEnemy == true)
        {
            if (collision.transform.tag == "Player")
            {
                Debug.Log("Hits player");
                Destroy(gameObject);
                collision.gameObject.GetComponent<PlayerStats>().ChangeHealth(-BulletDamage);
            }
        }
        else
        {
            if(collision.transform.tag == "Enemy")
            {
                Debug.Log("Hits enemy");
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
