using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.U2D;

public class NormalEnemy : MonoBehaviour {

    public float speed;
    public SpriteRenderer sp;

    private Player player;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private bool moveForward;
    private Rigidbody2D rb;

    void Start() {
        player = Player.player;
        startPoint = transform.Find("sensors/startPoint").position;
        endPoint = transform.Find("sensors/endPoint").position;

        rb = GetComponent<Rigidbody2D>();
    }


    void Update() {
        // follow player
        sp.flipX = !moveForward;
        if (moveForward) {
            rb.position = Vector2.MoveTowards(transform.position, endPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, endPoint) < 0.25f) {
                moveForward = false;
            }
        } else {
            rb.position = Vector2.MoveTowards(transform.position, startPoint, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, startPoint) < 0.25f) {
                moveForward = true;
            }
        }
    }
}
