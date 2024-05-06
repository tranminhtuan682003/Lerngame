using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingflatform : MonoBehaviour
{
    public float falldelay = 0.1f;
    public float destroydelay = 2f;
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2")){
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(falldelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroydelay);
    }
}
