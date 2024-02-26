using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 5;
    [SerializeField] private float turnspeed = 360;
    private Vector3 input;

    private bool isDead;

    public GameManage gameManage;

    // Animator reference
    private Animator animator;

    void Start()
    {
        // Get the Animator component attached to the player
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        GatherInput();
        Look();
        UpdateAnimationBooleans();
    }

    void FixedUpdate()
    {
        Move();
    }

    void GatherInput()
    {
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    void Look()
    {
        if (input != Vector3.zero)
        {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));

            var skewedInput = matrix.MultiplyPoint3x4(input);

            var relative = (transform.position + skewedInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnspeed * Time.deltaTime);
        }
    }

    void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude) * speed * Time.deltaTime);
    }

    void UpdateAnimationBooleans()
    {
        animator.SetBool("L", Input.GetKey(KeyCode.A));
        animator.SetBool("R", Input.GetKey(KeyCode.D));
        animator.SetBool("C", Input.GetKey(KeyCode.W));
        animator.SetBool("D", Input.GetKey(KeyCode.S));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap") && !isDead)
        {
            Destroy(gameObject);
            isDead = true;
            gameManage.gameOver();
        }
    }
}
