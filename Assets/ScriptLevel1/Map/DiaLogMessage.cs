using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class DiaLogMessage : MonoBehaviour
{
    public GameObject dialogPanel;
    public TextMeshPro dialogtext;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    void Update()
    {
        if (playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {
                ZeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
    }
    public void ZeroText()
    {
        dialogtext.text = "";
        index = 0;
        dialogPanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogtext.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void nextline()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogtext.text = "";
            StartCoroutine(Typing());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player2"))
        {
            playerIsClose = false;
            ZeroText();
        }
    }
}
