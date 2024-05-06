using UnityEngine;

public class EnemyTriggered : MonoBehaviour
{
    private bool isTriggerPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player2") isTriggerPlayer = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player2") isTriggerPlayer = false;
    }
    public bool GetTriggerPlayer()
    {
        return isTriggerPlayer;
    }
}
