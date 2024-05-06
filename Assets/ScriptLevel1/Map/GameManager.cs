using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject ReSpawpoint;
    public GameObject player;
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if(gameOverUI.activeInHierarchy)
        //{
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.None;
        //}
    }
    public void gameover()
    {
        gameOverUI.SetActive(true);
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restart");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
        Debug.Log("main menu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
