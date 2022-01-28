using UnityEngine;

public class Player : MonoBehaviour {

    public static Player player;

    [Header("Movement")]
    public float speed;
    public float maxSpeed;
    [Range(0f, 1f)] public float slowDownFactor;

    [Header("Jump")]
    public float jumpPower;

    [Header("Crouch")]
    private Vector2 initColliderSize;
    private Vector2 initColliderOffset;
    public Vector2 crouchColliderSize;
    public Vector2 crouchColliderOffset;

    [Header("sensors")]
    public Transform groundSensor;
    public float groundSensorRadius;
    public Transform ceilSensor;
    public float ceilSensorRadius;
    private bool isGrounded;
    private bool isCeil;

    // Components
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private void Awake() {
        player = this;
    }

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

        initColliderSize = boxCollider.size;
        initColliderOffset = boxCollider.offset;
    }


    void Update() {
        // get input
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        // movement
        if (h != 0) {
            rb.AddForce(h * speed * Vector2.right, ForceMode2D.Impulse);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y);
        } else {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, slowDownFactor), rb.velocity.y);
        }

        // check sensors
        isGrounded = Physics2D.OverlapCircleAll(groundSensor.position, groundSensorRadius).Length > 1; // bacause my collider is always counted
        isCeil = Physics2D.OverlapCircleAll(ceilSensor.position, ceilSensorRadius).Length > 1; // bacause my collider is always counted

        // jumping
        if (Input.GetKeyDown(KeyCode.W) && isGrounded && !isCeil) {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        // crouching
        if (Input.GetKey(KeyCode.S)) {
            Crouch(true);
        } else if (!isCeil) {
            Crouch(false);
        }

    }

    private void Crouch(bool getDown) {
        boxCollider.size = getDown ? crouchColliderSize : initColliderSize;
        boxCollider.offset = getDown ? crouchColliderOffset : initColliderOffset;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(groundSensor.position, groundSensorRadius);
        Gizmos.DrawWireSphere(ceilSensor.position, ceilSensorRadius);
    }
}

// TODO: implement deacceleration to limit Rigidbody's speed
