using UnityEngine;

public class NormalDungeon : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform telPos;
    [SerializeField] private Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        // 플레이어 던전 입장 처리
        // 위치 이동 및 던전 초기화
        player.position = telPos.position;
    }
}
