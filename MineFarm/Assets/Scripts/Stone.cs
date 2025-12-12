using System.Collections;
using UnityEngine;

public class Stone : MonoBehaviour, IMinable
{
    [SerializeField] private float hp = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 기본 HP 설정
        // 보상 설정
        // 확률적 아이템 드랍 설정
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DecreaseHp(float dmg)
    {
        hp -= dmg;
    }

    public bool HpBelowZero()
    {
        if (hp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Finish()
    {
        Destroy(gameObject);
    }

    public int GetReward()
    {
        return 1;
    }
}
