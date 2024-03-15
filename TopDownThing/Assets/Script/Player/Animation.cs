using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationBooleans();
    }

    void UpdateAnimationBooleans()
    {
        animator.SetBool("L", Input.GetKey(KeyCode.A));
        animator.SetBool("R", Input.GetKey(KeyCode.D));
        animator.SetBool("C", Input.GetKey(KeyCode.W));
        animator.SetBool("D", Input.GetKey(KeyCode.S));
    }
}
