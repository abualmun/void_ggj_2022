using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour {

    public static PlayerCombat player;
    public event Action onGotAttacked;
    public event Action onPlayerDead;

    public void GotAttacked() {
        if (onGotAttacked != null) {
            onGotAttacked();
        }
    }
    public void PlayerDead() {
        if (onPlayerDead != null) {
            onPlayerDead();
        }

    }

    public Transform attackPoint;
    public float attackRadius;
    public float maxHealth;
    public float hitDamage;
    private float health;

    private void Awake() {
        player = this;
    }

    void Start() {
        health = maxHealth;
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.H)) {
            foreach (var collider in Physics2D.OverlapCircleAll(transform.position, attackRadius)) {
                EnemyCombat enemy = collider.GetComponent<EnemyCombat>();
                enemy?.GetAttacked();
            }
        }

        if (health <= 0) {
            PlayerDead();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        switch (other.collider.tag) {
            case "Enemy":
                health -= hitDamage;
                GotAttacked();
                break;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }
}
