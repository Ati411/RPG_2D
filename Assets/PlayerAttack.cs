using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float AttackDamage = 10f;
    private int enemyLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == enemyLayer)
        {
            collision.GetComponent<Enemy>().TakeDamage(AttackDamage);
        }
    }
}
