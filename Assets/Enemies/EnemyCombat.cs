using UnityEngine;

public class EnemyCombat : MonoBehaviour {

    public float maxHealth;
    public float hitDamage;
    private float health;

    void Start() {
        health = maxHealth;
    }

    void Update() {
        if (health <= 0) {
            Die();
        }
    }

    public void GetAttacked() {
        health -= hitDamage;
    }

    private void Die() {
        // update UI
        // play die animation
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Player")) return;
        // play hit animation
    }
}
