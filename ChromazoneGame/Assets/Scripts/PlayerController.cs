using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletCooldown;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int bulletDamage;
    private float counter = 0f;
    
    [SerializeField] private GameObject tower1;
    [SerializeField] private GameObject tower2;
    [SerializeField] private GameObject tower3;
    private GameObject currentSelectedTower;
    [SerializeField] private float placementRadius;
    [SerializeField] private Image radiusUI;
    [SerializeField] private Image placementUI;
    
    [SerializeField] private float speed;
    private Vector2 playerInput = new Vector2();
    private Rigidbody2D rb;
    private Vector3 worldMousePosition;
    
    private enum playerState
    {
        SHOOTING,
        PLACING,
        PAUSED
    };
    [SerializeField]
    private playerState currentState = playerState.SHOOTING;
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        radiusUI.enabled = false;
        placementUI.enabled = false;
    }

    private void Update()
    {
        worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        worldMousePosition.z = 0;
        transform.up = transform.position - worldMousePosition;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            radiusUI.enabled = true;
            placementUI.enabled = true;
            currentSelectedTower = tower1;
            currentState = playerState.PLACING;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            radiusUI.enabled = true;
            placementUI.enabled = true;
            currentSelectedTower = tower2;
            currentState = playerState.PLACING;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            radiusUI.enabled = true;
            placementUI.enabled = true;
            currentSelectedTower = tower3;
            currentState = playerState.PLACING;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            placementUI.enabled = false;
            radiusUI.enabled = false;
            currentState = playerState.SHOOTING;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            placementUI.enabled = false;
            radiusUI.enabled = false;
            currentState = playerState.PAUSED;
        }
        if (currentState == playerState.PAUSED)
        {
            
        }
        else if (currentState == playerState.SHOOTING)
        {
            Shoot();
            Move();
        }
        else if (currentState == playerState.PLACING)
        {
            PlaceTower(currentSelectedTower);
        }
    }

    private void FixedUpdate()
    {
        if (currentState == playerState.SHOOTING)
        {
            rb.MovePosition(rb.position + playerInput * speed);
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        playerInput.x = inputX;
        playerInput.y = inputY;
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
            GameObject spawnBullet = Instantiate(bullet, transform.position, transform.rotation);
            spawnBullet.GetComponent<Bullet>().SetBulletDamage(bulletDamage);
           var direction = worldMousePosition - transform.position;
            direction.z = 0;
            direction.Normalize();
            var velocity = direction * bulletSpeed;
            spawnBullet.GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "goldItem")
        {
            Destroy(other);
            GetComponent<PlayerStats>().ChangeGold(5);
        }
        else if (other.tag == "healthItem")
        {
            Destroy(other); 
            GetComponent<PlayerStats>().ChangeHealth(10);
        }
    }
}
