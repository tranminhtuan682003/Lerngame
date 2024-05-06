using UnityEngine;

public class Wallcheckplayer : MonoBehaviour
{
    [SerializeField]private float speedFalling;
    private Rigidbody2D playerRigidbody;
    private void Start()
    {
        playerRigidbody = GameObject.FindGameObjectWithTag("player2").GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tilemap"))
        {
            Debug.Log("da cham tilemap");
            playerRigidbody.gravityScale = 0f;
            playerRigidbody.AddForce(Vector2.up * speedFalling, ForceMode2D.Impulse);
        }
    }
}
