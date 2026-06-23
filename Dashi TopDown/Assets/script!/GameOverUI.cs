using System.Collections;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;

    private bool isGameOver = false;

    public void ShowGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        GameManager.Instance.SaveDeath();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("GameOverPanel이 연결되지 않았습니다!");
        }

        yield return new WaitForSecondsRealtime(2f);

        GameManager.Instance.GoTitle();
    }
}