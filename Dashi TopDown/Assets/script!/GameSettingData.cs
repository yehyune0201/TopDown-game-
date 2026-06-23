using UnityEngine;

[CreateAssetMenu(menuName = "Game Data/Game SettingData")]
public class GameSettingData : ScriptableObject
{
    public int startHp = 100;

    public int startAttack = 10;

    // 기본 이동 속도
    public float playerMoveSpeed = 5f;

    // 아이템 1개당 증가하는 속도
    public float moveSpeedBonusPerItem = 0.2f;

    public int hpBounsPerDeath = 5;

    public int atkBounusPerDeath = 1;
}