using UnityEngine;
using UnityEngine.SceneManagement;

public class QuanliGame : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;
    public void gameover()
    {
        gameOverUI.SetActive(true);
    }
    private void Update()
    {
        bool playerHasActivate = player.activeInHierarchy;
        if (!playerHasActivate)
        {
            gameover();
        }
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartGame");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
