using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    private int coin;
    [SerializeField] private TMP_Text coindisplay;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    private void OnGUI()
    {
        coindisplay.text = coin.ToString();
    }
    public void changecoins(int amount)
    {
        coin += amount;

    }

}
