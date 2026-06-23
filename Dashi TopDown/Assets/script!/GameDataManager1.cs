using System.IO;
using UnityEngine;
using System.Linq;
public class GameDataManager1 : MonoBehaviour
{
   
    public static GameDataManager1 Instance;

    public GameSettingData gameSettingData;

    public SaveData saveData;

    public int isTutorialFinished;

    private string savePath;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            savePath = Application.persistentDataPath + "/saveData.json";

            LoadJsonData();
            LoadPlayerPrefs();

        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetPlayerHp()
    {
        int baseHp = gameSettingData.startHp;
        int bounusHp = gameSettingData.hpBounsPerDeath;

        return baseHp + bounusHp * saveData.deathCount;
    }
    public int GetPlayerAttack()
    {
        int baseAttack = gameSettingData.startAttack;
        int bounusAttack = gameSettingData.hpBounsPerDeath;

        return baseAttack + bounusAttack * saveData.deathCount;
    }

    public float GetPlayerMoveSpeed()
    {
        return gameSettingData.playerMoveSpeed +
        saveData.ItemCount * gameSettingData.moveSpeedBonusPerItem; //
    }

    public void SaveGameResult()
    {
        saveData.deathCount++;

        SaveJsonData();
    }

    public void SaveJsonData()
    {
        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(savePath, json);

        Debug.Log("JSON 저장 완료: " + savePath);
    }
    public void LoadJsonData()
    {
        if(File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            saveData = new SaveData();
            SaveJsonData();
        }
    }

    public void DeleteJsonData()
    {
        if (File.Exists(savePath))
        {
            File.Delete(savePath);
        }
        
            saveData = new SaveData();
            SaveJsonData();

        Debug.Log("JSON 저장 데이터 삭제");
    }

    public void LoadPlayerPrefs()
    {
        isTutorialFinished = PlayerPrefs.GetInt("TUTORIAL", 0);
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("TUTORIAL", isTutorialFinished);
        PlayerPrefs.Save();

        Debug.Log("PlayerPrefs 저장 완료");
    }
    public void ResetGameData()
    {
        saveData = new SaveData();
        SaveJsonData();

        if (GameUI.Instance != null)
        {
            GameUI.Instance.RefreshUI();
        }

        Debug.Log("게임 데이터 초기화 완료");
    }

    public void AddItem()
    {
        saveData.ItemCount++;

        Debug.Log("아이템 카운트 증가: " + saveData.ItemCount);

        SaveJsonData();
    }

    public int GetItemCount()
    {
        return saveData.ItemCount;
    }

    public bool HasItem(string itemId)
    {
        return saveData.collectedItemIds.Contains(itemId);
    }

    public void AddCollectedItem(string itemId)
    {
        if (HasItem(itemId)) return;

        saveData.ItemCount++;

        var list = saveData.collectedItemIds.ToList();
        list.Add(itemId);
        saveData.collectedItemIds = list.ToArray();

        SaveJsonData();
    }
   
}
