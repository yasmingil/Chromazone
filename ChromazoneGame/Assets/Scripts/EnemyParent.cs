using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    [SerializeField] private float goldDrop;
    [SerializeField] private float healthDrop;
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] private float towerDamage;
    [SerializeField] private float playerDamage;

    [SerializeField] private GameObject target;

    [SerializeField] private bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        


        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 ownerPos = transform.position;
        Vector3 ownerToTarget = targetPos - ownerPos;
        ownerToTarget.Normalize();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        transform.position += ownerToTarget * speed * Time.deltaTime;


    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "tower")
        {
            Debug.Log("hit a tower");
            speed = 0f;
        }
    }
}
