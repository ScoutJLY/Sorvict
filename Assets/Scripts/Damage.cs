using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        var health = col.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}