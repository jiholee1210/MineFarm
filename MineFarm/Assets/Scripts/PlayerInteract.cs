using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    PlayerAnimator playerAnimator;
    PlayerInventory playerInventory;
    bool canInteract = false;
    bool isMining = false;

    IInteractable curInteract;
    List<IMinable> minable = new();

    Coroutine mineCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<PlayerAnimator>();
        playerInventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DetectMovement()
    {
        if(isMining)
        {
            isMining = false;
            StopCoroutine(mineCoroutine);
            mineCoroutine = null;
            playerAnimator.SetMining(false);
        }
    }

    IEnumerator Mine()
    {
        float atkSpeed = 0.33f;
        playerAnimator.SetMiningSpeed(atkSpeed);
        playerAnimator.SetMining(true);
        // 특정 시간마다 채굴 반복
        IMinable temp = minable[0];
        while(true)
        {
            if(temp.HpBelowZero())
            {
                isMining = false;
                playerAnimator.SetMining(false);
                // 보상 획득
                playerInventory.AddGold(temp.GetReward());
                temp.Finish();
                SelectNextStone();
                yield break;
            }
            yield return new WaitForSeconds(atkSpeed);
            temp.DecreaseHp(1f);
        }
    }

    private void SelectNextStone()
    {
        // 다음 광물 UI 강조 표시
        Debug.Log(minable.Count + " " + isMining);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 상호작용 물체 감지 후 처리
        // 해당 물체 테두리 강조 표시 및 상호작용 가능 상태 처리
        switch (collision.tag)
        {
            case "Interactable":
                Debug.Log("Interactable Object Detected");
                canInteract = true;
                curInteract = collision.GetComponent<IInteractable>();
                break;
            case "Stone":
                Debug.Log("Minable Object Detected");
                minable.Add(collision.GetComponent<IMinable>()); 
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Interactable Object Out");
        switch (collision.tag)
        {
            case "Interactable":
                curInteract = null;
                canInteract = false;
                break;
            case "Stone":
                minable.Remove(collision.GetComponent<IMinable>());
                break;
        }
    }

    public void OnInteract()
    {
        Debug.Log("상호작용 실행");
        if(canInteract && curInteract != null)
        {
            Vector3 pos = curInteract.Interact();
            transform.position = pos;
        }
    }

    public void OnAttack()
    {
        if(!isMining && minable.Count > 0)
        {
            isMining = true;
            mineCoroutine = StartCoroutine(Mine());
        }
    }
}
