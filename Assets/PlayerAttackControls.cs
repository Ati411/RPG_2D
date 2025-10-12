using UnityEngine;

public class PlayerAttackControls : MonoBehaviour
{
    public PlayerMoveControl playerMoveControl;
    private Gatherinput gatherinput;
    private Animator animator;
    public bool AttackStarted = false;
    public PolygonCollider2D attackCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMoveControl = GetComponent<PlayerMoveControl>();
        gatherinput = GetComponent<Gatherinput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    private void Attack()
    {
        if (gatherinput.tryAttack)
        {
            animator.SetBool("Attack", true);
            AttackStarted = true;
        }
    }
    public void ResetAttack()
    {
        animator.SetBool("Attack", false);
        gatherinput.tryAttack = false;
        AttackStarted = false;
        attackCollider.enabled = false;
    }
    public void ActiveAttack()
    {
        attackCollider.enabled = true;
    }
}
