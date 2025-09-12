using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public UIManager uiManager;
    public float maxHealth;
    public float health;
    public Slider HealthSlider;
    private bool CanTakeDamage = true;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        health = maxHealth;

        if (HealthSlider != null)
        {
            HealthSlider.maxValue = maxHealth;
            HealthSlider.value = health;
        }
    }

    // Update is called once per frame
    public void TakeDamage(float damage)
    {
        if (!CanTakeDamage)
        {
            return;
        }
        health -= damage;
        anim.SetBool("Damage", true);

        if (HealthSlider != null)
        {
            HealthSlider.value = health;
        }

        if (health <= 0)
        {
            health = 0;
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponentInParent<Gatherinput>().DisableControls();
            Debug.Log("Player is dead");
            uiManager.ShowGameOverScreen();
        }
        StartCoroutine(DamagePrevention());
    }
    private IEnumerator DamagePrevention()
    {
        CanTakeDamage = false;
        yield return new WaitForSeconds(0.15f);
        if (health > 0)
        {
            CanTakeDamage = true;
            anim.SetBool("Damage", false);
        }
        else
        {
            anim.SetBool("Death", true);
        }
    }
}
