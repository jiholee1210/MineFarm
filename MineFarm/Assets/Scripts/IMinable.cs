using UnityEngine;

public interface IMinable
{
    void DecreaseHp(float dmg);
    bool HpBelowZero();
    void Finish();
    int GetReward();
}
