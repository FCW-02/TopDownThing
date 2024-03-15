using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCha : MonoBehaviour
{
    private Animator animator;
    private AudioSource walkSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        walkSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimationBooleans();
        PlayWalkSound();
    }

    void UpdateAnimationBooleans()
    {
        animator.SetBool("L", Input.GetKey(KeyCode.A));
        animator.SetBool("R", Input.GetKey(KeyCode.D));
        animator.SetBool("C", Input.GetKey(KeyCode.W));
        animator.SetBool("D", Input.GetKey(KeyCode.S));
    }

    void PlayWalkSound()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            walkSound.Play();
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) ||
                 Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
        {
            walkSound.Stop();
        }
    }
}
