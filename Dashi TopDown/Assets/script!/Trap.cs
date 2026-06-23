using UnityEngine;

public class Trap : MonoBehaviour
{
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActivated)
            return;

        if (collision.CompareTag("Player"))
        {
            isActivated = true;

            if (GameOverUI.Instance != null)
            {
                GameOverUI.Instance.ShowGameOver();
            }
        }
    }
}