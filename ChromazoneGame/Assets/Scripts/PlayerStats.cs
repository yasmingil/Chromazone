using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int health = 100;
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

    public void ChangeGold(int goldChange)
    {
        goldAmt += goldChange;
    }

    public int GetGoldAmt()
    {
        return goldAmt;
    }

}
