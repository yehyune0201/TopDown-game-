using UnityEngine;

[System.Serializable]
public class SaveData
{
    public int deathCount;
    public int ItemCount;

    public string[] collectedItemIds = new string[0];
}

