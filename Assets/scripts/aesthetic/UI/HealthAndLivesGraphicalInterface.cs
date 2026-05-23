using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndLivesGraphicalInterface : MonoBehaviour
{

    public HealthSlice Mid1;
    public HealthSlice Mid2;
    public HealthSlice Mid3;
    public HealthSlice petal1;
    public HealthSlice petal2;
    public HealthSlice petal3;
    public HealthSlice petal4;
    public HealthSlice petal5;
    public HealthSlice petal6;

    public void Update()
    {
        ///   LIFE   ///
        if(PlayerHealth.current.Life == 3)
        {
            Mid1.UIElement.sprite = Mid1.Full;
            Mid2.UIElement.sprite = Mid2.Full;
            Mid3.UIElement.sprite = Mid3.Full;
        }
        if (PlayerHealth.current.Life == 2)
        {
            Mid1.UIElement.sprite = Mid1.Full;
            Mid2.UIElement.sprite = Mid2.Full;
            Mid3.UIElement.sprite = Mid3.Empty;
        }
        if (PlayerHealth.current.Life == 1)
        {
            Mid1.UIElement.sprite = Mid1.Full;
            Mid2.UIElement.sprite = Mid2.Empty;
            Mid3.UIElement.sprite = Mid3.Empty;
        }
        ///   HEALTH   ///
        if(PlayerHealth.current.health == 6)
        {
            petal1.UIElement.sprite = petal1.Full;
            petal2.UIElement.sprite = petal2.Full;
            petal3.UIElement.sprite = petal3.Full;
            petal4.UIElement.sprite = petal4.Full;
            petal5.UIElement.sprite = petal5.Full;
            petal6.UIElement.sprite = petal6.Full;
        }
        if (PlayerHealth.current.health == 5)
        {
            petal1.UIElement.sprite = petal1.Full;
            petal2.UIElement.sprite = petal2.Full;
            petal3.UIElement.sprite = petal3.Full;
            petal4.UIElement.sprite = petal4.Full;
            petal5.UIElement.sprite = petal5.Full;
            petal6.UIElement.sprite = petal6.Empty;
        }
        if (PlayerHealth.current.health == 4)
        {
            petal1.UIElement.sprite = petal1.Full;
            petal2.UIElement.sprite = petal2.Full;
            petal3.UIElement.sprite = petal3.Full;
            petal4.UIElement.sprite = petal4.Full;
            petal5.UIElement.sprite = petal5.Empty;
            petal6.UIElement.sprite = petal6.Empty;
        }
        if (PlayerHealth.current.health == 3)
        {
            petal1.UIElement.sprite = petal1.Full;
            petal2.UIElement.sprite = petal2.Full;
            petal3.UIElement.sprite = petal3.Full;
            petal4.UIElement.sprite = petal4.Empty;
            petal5.UIElement.sprite = petal5.Empty;
            petal6.UIElement.sprite = petal6.Empty;
        }
        if (PlayerHealth.current.health == 2)
        {
            petal1.UIElement.sprite = petal1.Full;
            petal2.UIElement.sprite = petal2.Full;
            petal3.UIElement.sprite = petal3.Empty;
            petal4.UIElement.sprite = petal4.Empty;
            petal5.UIElement.sprite = petal5.Empty;
            petal6.UIElement.sprite = petal6.Empty;
        }
        if (PlayerHealth.current.health == 1)
        {
            petal1.UIElement.sprite = petal1.Full;
            petal2.UIElement.sprite = petal2.Empty;
            petal3.UIElement.sprite = petal3.Empty;
            petal4.UIElement.sprite = petal4.Empty;
            petal5.UIElement.sprite = petal5.Empty;
            petal6.UIElement.sprite = petal6.Empty;
        }
    }

    [System.Serializable]
    public struct HealthSlice
    {
        public Sprite Empty;
        public Sprite Full;
        public Image UIElement;
    }
}
