using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quykiem : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller player = collision.gameObject.GetComponent<playercontroller>();
            if (player != null && !player.Hasquykiem()) {
                player.setquykiem(true);
                Destroy(gameObject);
            }
        }
    }
}
