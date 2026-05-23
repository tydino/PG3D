using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Life;
    public int health;

    public Mode EasyMode;
    public Mode MediumMode;
    public Mode HardMode;

    private void Awake()
    {
        EasyMode.Lives = 3;
        EasyMode.BaseLineHealth = 6;
        MediumMode.Lives = 1;
        MediumMode.BaseLineHealth = 6;
        HardMode.Lives = 1;
        HardMode.BaseLineHealth = 1;
    }

    [System.Serializable]
    public struct Mode
    {
        public int Lives;
        public int BaseLineHealth;
    }
}