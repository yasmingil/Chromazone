using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletCooldown;
    private float counter = 0f;
    [SerializeField] private enum shotType { SPREAD, SINGLE };
    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // constant shooting of bullets
        if (counter <= bulletCooldown)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            GameObject spawnBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            // Get player position
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            var direction = player.transform.position - transform.position;
            direction.z = 0;
            direction.Normalize();
            var velocity = direction * bulletSpeed;
            spawnBullet.GetComponent<Rigidbody2D>().velocity = velocity;
        }
        

        // TODO:
        // limit range on gunners? (not shooting from across the map)
    }
}
