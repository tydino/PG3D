using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth current;

    public int Life;
    public int health;

    public Mode EasyMode;
    public Mode MediumMode;
    public Mode HardMode;

    private void Awake()
    {
        current = this;
        EasyMode.Lives = 3;
        EasyMode.BaseLineHealth = 6;
        MediumMode.Lives = 3;
        MediumMode.BaseLineHealth = 3;
        HardMode.Lives = 1;
        HardMode.BaseLineHealth = 1;
    }

    private void Update()
    {
        modes mode = SaveData.current.sdmode.currentMode;
        if (health <= 0)
        {
            if(mode == modes.easy)
            {
                health = EasyMode.BaseLineHealth;
            }
            if (mode == modes.medium)
            {
                health = MediumMode.BaseLineHealth;
            }
            if (mode == modes.hard)
            {
                health = HardMode.BaseLineHealth;
            }
            Life--;
        }
        if (Life <= 0)
        {
            SceneChanger.ChangeScene("GameOver");
        }
    }

    public void setMode()
    {
        modes mode = SaveData.current.sdmode.currentMode;
        if(mode == modes.easy)
        {
            Life = EasyMode.Lives;
            health = EasyMode.BaseLineHealth;
        }
        if (mode == modes.medium)
        {
            Life = MediumMode.Lives;
            health = MediumMode.BaseLineHealth;
        }
        if (mode == modes.hard)
        {
            Life = HardMode.Lives;
            health = HardMode.BaseLineHealth;
        }
    }

    [System.Serializable]
    public struct Mode
    {
        public int Lives;
        public int BaseLineHealth;
    }
}