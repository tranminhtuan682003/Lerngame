using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueWiza : MonoBehaviour
{
    public float speed;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player2").GetComponent<Transform>();
    }
    void Update()
    {
        followPlayer();
    }
    private void followPlayer()
    {
        if(Vector2.Distance(transform.position,player.position) > 0.5f)
        {
            Vector2 targetPosition = new Vector2(player.position.x, player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            }
            else
            {
                transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }

    }

}
