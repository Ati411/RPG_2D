using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    protected Rigidbody2D Rigidbody2D;
    protected Animator animator;
    private bool canTakeDamage = true;
    private void Awake()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float damage)
    {
        if (!canTakeDamage)
        {
            return;
        }
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            canTakeDamage = false;
            if (GetComponent<EnemyRedDog>() != null)
            {
                GetComponent<EnemyRedDog>().enabled = false;
            }
            if (GetComponent<Collider2D>() != null)
            {
                GetComponent<Collider2D>().enabled = false;
            }
            Rigidbody2D.linearVelocity = Vector2.zero;
            this.enabled = false;

            Destroy(gameObject, 0.77f);
        }
        else
        {
            StartCoroutine(DamageEffect());
        }
    }
    private IEnumerator DamageEffect()
    {
        canTakeDamage = false;
        animator.SetBool("Damage", true);
        yield return new WaitForSeconds(0.2f);
        animator.SetBool("Damage", false);
        canTakeDamage = true;
    }
}
