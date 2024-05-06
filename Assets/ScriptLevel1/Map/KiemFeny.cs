using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiemFeny : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller player = collision.gameObject.GetComponent<playercontroller>();
            if(player != null && !player.HasKiemFeny())
            {
                player.SetKiemFeny(true);
                Destroy(gameObject);
                Debug.Log("da nhan kiem feny");
            }
        }
    }
}
