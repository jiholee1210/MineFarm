using UnityEngine;

public class Portal : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform telPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 Interact()
    {
        return telPos.position;
    }
}
