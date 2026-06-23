using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemId;
    public float speedAmount = 2f;

    private void Start()
    {
        if (GameDataManager1.Instance.HasItem(itemId))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (GameDataManager1.Instance.HasItem(itemId))
                return;

            NewMonoBehaviourScript player = collision.GetComponent<NewMonoBehaviourScript>();

            if (player != null)
            {
                player.SpeedUp(speedAmount);

                GameDataManager1.Instance.AddCollectedItem(itemId);

                if (GameUI.Instance != null)
                {
                    GameUI.Instance.RefreshUI();
                }
            }

            Destroy(gameObject);
        }
    }
}