using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollision : MonoBehaviour
{
    bool isInteracting = false;

    IInteractable curInteract;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // 상호작용 물체 감지 후 처리
        // 해당 물체 테두리 강조 표시 및 상호작용 가능 상태 처리
        switch (collision.tag)
        {
            case "Interactable":
                Debug.Log("Interactable Object Detected");  
                curInteract = collision.GetComponent<IInteractable>();
                isInteracting = true;
                break;
            case "Stone":
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Interactable Object Out");
        curInteract = null;
        isInteracting = false;
    }

    public void OnInteract()
    {
        Debug.Log("상호작용 실행");
        if(isInteracting && curInteract != null)
        {
            curInteract.Interact();
        }
    }
}
