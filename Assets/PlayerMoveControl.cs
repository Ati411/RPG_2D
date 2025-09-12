using System.Xml.Serialization;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMoveControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float speed = 5f;
    private Gatherinput gatherInput;
    private Rigidbody2D Rigidbody2D;
    private int direction = 1;
    private Animator animator;
    public float JumpForce = 5f;
    private bool grounded = false;
    public Transform leftPoint;
    public float rayLength;
    public LayerMask GroundLayer;
    void Start()
    {
        gatherInput = GetComponent<Gatherinput>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetAnimatorValues();
        Flip();
        Rigidbody2D.linearVelocity = new Vector2(speed * gatherInput.valueX, Rigidbody2D.linearVelocity.y);
        JumpPlayer();
    }
    private void SetAnimatorValues()
    {
        animator.SetFloat("Speed", Mathf.Abs(Rigidbody2D.linearVelocityX));
        animator.SetFloat("vSpeed", Rigidbody2D.linearVelocityY);
        animator.SetBool("Ground", grounded);
    }
    private void FixedUpdate()
    {
        CheckStatus();
        Move();
        JumpPlayer();
    }
    private void Move()
    {
        Flip();
        Rigidbody2D.linearVelocity = new Vector2(speed * gatherInput.valueX, Rigidbody2D.linearVelocity.y);  
    }
    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
    private void JumpPlayer()
    {
        if (gatherInput.JumpInput && grounded)
        {
            Rigidbody2D.linearVelocity = new Vector2(gatherInput.valueX * speed, JumpForce);
        }
        gatherInput.JumpInput = false;
    }
    private void CheckStatus()
    {
        RaycastHit2D leftCheckHit = Physics2D.Raycast(leftPoint.position, Vector2.down, rayLength, GroundLayer);
        grounded = leftCheckHit;
    }
}

