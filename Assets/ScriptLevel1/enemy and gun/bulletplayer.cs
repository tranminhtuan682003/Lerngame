using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletplayer : MonoBehaviour
{
    public float life = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "BulletCanon")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "laze")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Drone")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Spider")
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(life);
        Destroy(gameObject);
    }
}
