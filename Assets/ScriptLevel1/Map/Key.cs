using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float timedelay;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playercontroller player = collision.gameObject.GetComponent<playercontroller>();
            if (player != null && !player.HasKey())
            {
                player.SetHasKey(true);
                StartCoroutine(WaitDestroy());
            }
        }
    }
    IEnumerator WaitDestroy()
    {
        yield return new WaitForSeconds(timedelay);
        Destroy(gameObject);
    }
}
