using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string gameSceneName = "ForestScene";

    public string endingSceneName = "Ending";

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void SaveDeath()
    {
        GameDataManager1.Instance.SaveGameResult();
    }

    public void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void GoEnding()
    {
        SceneManager.LoadScene(endingSceneName);
    }
}