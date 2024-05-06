using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if (collision.gameObject.tag == "player2")
        {
            playercontroller.Instance.Takedamage(20);
           gameObject.SetActive(false);
        }

    }
}
