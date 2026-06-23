using UnityEngine;

public class Endingpotal : MonoBehaviour
{
    public int needItemCount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int itemCount = GameDataManager1.Instance.GetItemCount();

            if (itemCount >= needItemCount)
            {
                Debug.Log("엔딩으로 이동!");
                GameManager.Instance.GoEnding();
            }
            else
            {
                Debug.Log("아이템이 부족합니다! 현재: " + itemCount + " / 필요: " + needItemCount);
            }
        }
    }
}