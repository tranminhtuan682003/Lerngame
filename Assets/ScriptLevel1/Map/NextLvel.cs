using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    public GameObject panelWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player2")) 
        {
            panelWin.SetActive(true);
        }
    }
}
