using System.Collections;
using UnityEngine;

public class TrapFalling : MonoBehaviour
{
    [SerializeField] private float timedelay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            StartCoroutine(Falling());
        }
    }

    IEnumerator Falling()
    {
        yield return new WaitForSeconds(timedelay);
        Destroy(gameObject);
    }
}
