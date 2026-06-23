using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI Instance;

    public TextMeshProUGUI itemText;
    public TextMeshProUGUI deathText;

    public int maxItemCount = 10;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        int itemCount = GameDataManager1.Instance.GetItemCount();

        itemText.text = $"Treasure : {itemCount} / {maxItemCount}";
        deathText.text = $"Death : {GameDataManager1.Instance.saveData.deathCount}";
    }
}