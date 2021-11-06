using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private float bulletSpeed;
    private float counter = 0f;
    
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    private GameObject currentSelected;
    [SerializeField] private float placementRadius;
    [SerializeField] private Image radiusUI;
    [SerializeField] private Image placementUI;
    
    [SerializeField] private float speed;
    private Vector2 playerInput = new Vector2();
    private Rigidbody2D rb;
    
    private enum playerState
    {
        SHOOTING,
        PLACING,
        PAUSED
    };

    private playerState currentState = playerState.SHOOTING;
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        radiusUI.enabled = false;
        placementUI.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSelected = tower1;
            currentState = playerState.PLACING;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSelected = tower2;
            currentState = playerState.PLACING;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSelected = tower3;
            currentState = playerState.PLACING;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentState == playerState.PLACING)
            {
                currentState = playerState.SHOOTING;
            }
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            currentState = playerState.PAUSED;
        }
        if (currentState == playerState.PAUSED)
        {
            
        }
        else if (currentState == playerState.SHOOTING)
        {
            Shoot();
        }
        else if (currentState == playerState.PLACING)
        {
            
        }
    }
    private void Shoot()
    {
        if (counter <= bulletCooldown)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            GameObject spawnBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
            var direction = worldMousePosition - transform.position;
            direction.z = 0;
            direction.Normalize();
            var velocity = direction * bulletSpeed;
            spawnBullet.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
    private void PlaceTower(GameObject tower)
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        float closestDist = float.MaxValue;
        foreach (var t in towers)
        {
            if (Vector3.Distance(t.transform.position, transform.position) <= closestDist)
            {
                
            }
        }
    }
}
