using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCanon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bulletplayer")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "tilemap")
        {
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller.Instance.Takedamage(40);
            gameObject.SetActive(false);
        }

    }
}
