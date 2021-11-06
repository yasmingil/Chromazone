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
        Vector3 mousePosition = Vector3.zero;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            mousePosition = new Vector3(hit.point.x, hit.point.y, 0);
        }
        var placeDir = (mousePosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, mousePosition);
        distance = Mathf.Min(distance, placementRadius);
        var placePosition = transform.position + placeDir * distance;
        Debug.Log(placePosition);
        placementUI.transform.position = placePosition;
        
        //GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        /*float closestDist = float.MaxValue;
        foreach (var t in towers)
        {
            float distToTower = Vector3.Distance(t.transform.position, transform.position)
            if (distToTower <= closestDist)
            {
                closestDist = distToTower;
            }
        }*/

    }
}
