using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorProxy : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBool(string name, bool value)
    {
        animator.SetBool(name, value);
    }

    public void FlipX(bool flipped)
    {
        spriteRenderer.flipX = flipped;
    }
}
