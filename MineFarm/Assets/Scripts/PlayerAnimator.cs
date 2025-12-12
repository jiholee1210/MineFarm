using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private AnimationClip mineClip;
    
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipSprite(float input)
    {
        if(input > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(input < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    public void SetWalk(float value)
    {
        animator.SetFloat("Blend", value);
    }

    public void SetMining(bool state)
    {
        animator.SetBool("IsMining", state);
    }

    public void SetMiningSpeed(float speed)
    {
        float clipLength = mineClip.length;
        float atkSpeed = clipLength / speed;
        animator.SetFloat("AtkSpeed", atkSpeed);
    }
}
