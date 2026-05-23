using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndLivesGraphicalInterface : MonoBehaviour
{
    public PlayerHealth currentPlayerHealth;

    public void Update()
    {

        if (currentPlayerHealth.Life <= 0)
        {
            SceneChanger.ChangeScene("GameOver");
        }
    }
}
