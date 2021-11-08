using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int health;
    [SerializeField] private int goldAmt;
    [SerializeField] private TMP_Text goldCount;
    [SerializeField] private Image healthBar;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        health = maxHealth;
        ChangeGold(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //take damage
    public void ChangeHealth(int healthChange)
    {
        health += healthChange;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        UpdateHealthBar();
        if(health<=0)
        {
            gameManager.GetComponent<GameManager>().LoseGame();
        }

    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)health/(float)maxHealth;
    }
    public void ChangeGold(int goldChange)
    {
        goldAmt += goldChange;
        goldCount.text = goldAmt.ToString();
    }
    
    public int GetGoldAmt()
    {
        return goldAmt;
    }

}
