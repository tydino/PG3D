using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndLivesGraphicalInterface : MonoBehaviour
{
    public Text lives, Health;
    public PlayerHealth currentPlayerHealth;
    public Lifes currentPlayerLives;

    public void Update()
    {

        int currentPlayerHealthInt = currentPlayerHealth.health;
        int currentPlayerHealthBaselineInt = currentPlayerHealth.baselineHealth;
        int currentPlayerLivesInt = currentPlayerLives.Life;

        //these if statements MAY need to go eventually.
        if(currentPlayerHealthInt <= 0)
        {
            currentPlayerHealth.health = currentPlayerHealthBaselineInt;
            currentPlayerLives.Life--;
        }

        if (currentPlayerLivesInt <= 0)
        {
            SceneChanger.ChangeScene("GameOver");
        }
        else {
            lives.text = "Lifes: " + currentPlayerLivesInt;
            Health.text = "Health: " + currentPlayerHealthInt;
        }
    }
}
