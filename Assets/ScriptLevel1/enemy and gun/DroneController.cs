using System.Collections;
using UnityEngine;

public class DroneController : MonoBehaviour
{
    [SerializeField] private float scale;
    [SerializeField] private Transform Boss;
    public playercontroller playerController;
    public float speedArmy;
    public bool isFollowing = false;
    private Animator animatorParent;

    private void Start()
    {
        animatorParent = transform.parent.GetComponent<Animator>();
    }

    void Update()
    {
        if (isFollowing)
        {
            if (playerController != null)
            {
                Vector2 targetPosition = new Vector2(playerController.transform.position.x, Boss.position.y);
                Boss.position = Vector2.MoveTowards(Boss.position, targetPosition, speedArmy * Time.deltaTime);
                if (playerController.transform.position.x > Boss.position.x)
                {
                    Boss.localScale = new Vector3(scale, scale, scale);
                }
                else
                {
                    Boss.localScale = new Vector3(-scale, scale, scale);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            isFollowing = true;
            if (animatorParent != null)
            {
                animatorParent.SetBool("IsWalk", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            isFollowing = false;
            if (animatorParent != null)
            {
                animatorParent.SetBool("IsWalk", false); 
            }
        }
    }
}
