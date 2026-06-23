using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time = 60f;
    public TextMeshProUGUI timerText;

    bool isTimeOver = false;

    void Update()
    {
        if (isTimeOver)
            return;

        time -= Time.deltaTime;

        if (time < 0)
            time = 0;

        int minute = Mathf.FloorToInt(time / 60);
        int second = Mathf.FloorToInt(time % 60);

        timerText.text = $"Sunset : {minute:00}:{second:00}";

        if (time <= 0)
        {
            isTimeOver = true;

            GameOverUI gameOverUI = FindFirstObjectByType<GameOverUI>();

            if (gameOverUI != null)
            {
                gameOverUI.ShowGameOver();
            }
            else
            {
                Debug.LogError("GameOverUI가 씬에 없습니다!");
            }
        }
    }
}