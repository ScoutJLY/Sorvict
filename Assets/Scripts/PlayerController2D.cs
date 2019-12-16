using UnityEngine.SceneManagement;
using UnityEngine;


public class PlayerController2D : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public CharacterController2D controller;
    public Animator animator;
    public GameObject dashEffect;

    private float dashRate = 1.5f;
    private float lastDash = -1.5f;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    private float dashSpeed = 20000f;

    void Update()
    {
        //Debug.Log(jump);

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.time > dashRate + lastDash)
            {
                lastDash = Time.time;

                var face = GetComponent<CharacterController2D>();

                Instantiate(dashEffect, transform.position, Quaternion.identity);
                if (face.m_FacingRight)
                {
                    rigidBody.velocity = new Vector2(dashSpeed, 0);
                }
                else
                {
                    rigidBody.velocity = new Vector2(-dashSpeed, 0);
                }
                animator.SetFloat("Speed", Mathf.Abs(rigidBody.velocity.x));
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        
        jump = false;
    }
}