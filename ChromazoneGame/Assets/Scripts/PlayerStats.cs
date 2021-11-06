using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health = 100;
    [SerializeField] private int goldAmt;
    [SerializeField] private int goldValue = 20;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //take damage
    public void ChangeHealth(int healthChange)
    {
        health += healthChange;
    }

    //pick up gold
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "gold")
        {
            Debug.Log("hit gold");

            goldAmt += goldValue;
            Debug.Log(goldAmt);

        }
    }
    public void SpendGold(int gold)
    {
        goldAmt -= gold;
    }

}
