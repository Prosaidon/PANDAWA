using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private Text coinText;

    private int coinAmount;

    [SerializeField]
    private GameObject[] healthObj;
    //private List<GameObject> healthObj; // Anda perlu mengaktifkan atau menonaktifkan objek kesehatan

    private void Start()
    {
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Jumlah Coin: " + coinAmount;
    }

    public void AddCoin(int amount)
    {
        coinAmount += amount;
        UpdateCoinText();
    }

    public void SetHealthObj(float healthPercentage)
    {
        if (healthPercentage >= 1.0f)
        {
            SetAllHealthObjects(true);
        }
        else if (healthPercentage >= 0.67f)
        {
            SetHealthObjects(true, true, false);
        }
        else if (healthPercentage >= 0.33f)
        {
            SetHealthObjects(true, false, false);
        }
        else
        {
            SetAllHealthObjects(false);
        }
    }

    private void SetAllHealthObjects(bool active)
    {
        foreach (GameObject obj in healthObj)
        {
            obj.SetActive(active);
        }
    }

    private void SetHealthObjects(bool firstActive, bool secondActive, bool thirdActive)
    {
        healthObj[0].SetActive(firstActive);
        healthObj[1].SetActive(secondActive);
        healthObj[2].SetActive(thirdActive);
    }
}
