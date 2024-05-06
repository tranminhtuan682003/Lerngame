using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hastrigger;
    private CoinManager manager;

    private void Start()
    {
        manager = CoinManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hastrigger)
        {
            hastrigger = true;
            manager.changecoins(value);
            Destroy(gameObject);
        }
    }
}
