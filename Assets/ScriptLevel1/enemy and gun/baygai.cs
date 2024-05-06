using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baygai : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player2")
        {
            playercontroller.Instance.Takedamage(80);
        }
    }
}
