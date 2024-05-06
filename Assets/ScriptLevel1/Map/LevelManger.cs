using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManger : MonoBehaviour
{
    public static LevelManger instance; // Sửa đổi từ SceneController thành LevelManger
    public GameObject player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(player);
        }
        else
        {
            Destroy(player);
        }
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); // Sử dụng LoadScene thay vì LoadSceneAsync nếu không cần thiết
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName); // Sử dụng LoadScene thay vì LoadSceneAsync nếu không cần thiết
    }
}
