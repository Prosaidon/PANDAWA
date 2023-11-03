using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Image healthBar;

    [SerializeField]
    private int playerHealth = 1; // Mengatur kesehatan awal ke 1

    private void UpdatePlayerHealth()
    {
        if (GameManager.instance != null)
        {
            float healthPercentage = (float)playerHealth / 3.0f; // Mengubah integer ke float
            healthBar.fillAmount = healthPercentage;
            GameManager.instance.SetHealthObj(healthPercentage);
        }
    }
}
