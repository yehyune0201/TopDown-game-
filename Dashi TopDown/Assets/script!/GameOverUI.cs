using System.Collections;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    public GameObject gameOverPanel;

    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        GameManager.Instance.SaveDeath();

        gameOverPanel.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);

        GameManager.Instance.GoTitle();
    }
}