using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdichchuyen : MonoBehaviour
{
    private GameObject currentteleporter;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentteleporter != null)
            {
                transform.position = currentteleporter.GetComponent<testdichchuyen>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teleporter"))
        {
            currentteleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("teleporter"))
        {
            if(collision.gameObject == currentteleporter)
            {
                currentteleporter = null;
            }
        }
    }
}
