using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axit : MonoBehaviour
{
    public playercontroller playercontrollerr;
    public float damagePerSecond = 0.1f;
    private bool isPlayerInside = false;

    void Update()
    {
        if (isPlayerInside)
        {
            playercontrollerr.Takedamage(damagePerSecond); // Mất máu theo thời gian
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player2"))
        {
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("player2"))
        {
            isPlayerInside = false;
        }
    }
}
