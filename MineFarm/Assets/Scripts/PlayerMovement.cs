using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    float inputX;
    float inputY;
    Rigidbody2D rigidbody2D;
    PlayerAnimator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        rigidbody2D.linearVelocityX = inputX * speed;
        rigidbody2D.linearVelocityY = inputY * speed;
    }

    public void OnMove(InputValue value) 
    {
        inputX = value.Get<Vector2>().x;
        inputY = value.Get<Vector2>().y;
        playerAnimator.FlipSprite(inputX);
        playerAnimator.SetWalk(Mathf.Abs(inputX) + Mathf.Abs(inputY));
    }
}
