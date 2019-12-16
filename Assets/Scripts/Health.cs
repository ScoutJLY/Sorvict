using UnityEngine;

public class Health : MonoBehaviour
{
    public int startingHealth = 5;

    public int currentHealth;

    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.tag == "Boss")
        {

        }

        if (gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }

        if (gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Hurt");
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}