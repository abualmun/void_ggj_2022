using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class Force : MonoBehaviour {

    public float explosionForce;
    public float explosionRadius;

    private Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.J)) {
            Explode();
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            Explode(false);
        }
    }

    void Explode(bool push = true) {

        foreach (var collider in Physics2D.OverlapCircleAll(transform.position, explosionRadius)) {
            // Rigidbody2D
            Rigidbody2D rigidbody;
            if (!collider.TryGetComponent<Rigidbody2D>(out rigidbody)) continue;
            if (rigidbody.tag == "Player") continue;
            rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, push: push);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

public static class Rigidbody2DExt {

    public static void AddExplosionForce(this Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Impulse, bool push = true) {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;
        // Normalize without computing magnitude again
        if (upwardsModifier == 0)
            explosionDir /= explosionDistance;
        else {
            // From Rigidbody.AddExplosionForce doc:
            // If you pass a non-zero value for the upwardsModifier parameter, the direction
            // will be modified by subtracting that value from the Y component of the centre point.
            explosionDir.y += upwardsModifier;
            explosionDir.Normalize();
        }

        var forceDir = Mathf.Lerp(0, explosionForce, (explosionRadius - explosionDistance) / explosionRadius) * explosionDir;
        forceDir *= (push ? 1 : -1);
        rb.AddForce(forceDir, mode);
    }
}
