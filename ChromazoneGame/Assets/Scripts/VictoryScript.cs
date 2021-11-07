using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    // public GameObject MainMenu;
    // public GameObject CreditsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayAgainButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        UnityEngine.SceneManagement.SceneManager.LoadScene("MasterScene");
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}