using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Game SettingData")]
public class GameSettingData : ScriptableObject
{

    public int startHp = 100;

    public int startAttack = 10;

    public float playerMoveSpeed = 5f;

    public int hpBounsPerDeath = 5;

    public int atkBounusPerDeath = 1;


}
