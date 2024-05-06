using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazeTutorial : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float distance = 10f;
    RaycastHit2D hit;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * speed*Time.deltaTime);
        hit = Physics2D.Raycast(transform.position, transform.forward, distance);
        if(hit.collider != null)
        {
            Debug.DrawRay(transform.position,hit.point, Color.white);
            Debug.Log("did hit");

        }
        else
        {
            Debug.DrawRay(transform.position,transform.position + transform.right*distance,Color.black);
            Debug.Log("did not hit");
        }
    }
}
