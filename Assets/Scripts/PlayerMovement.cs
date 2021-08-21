using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement INSTANCE { get; private set; }
    
    private Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        INSTANCE = this;
    }

    private void Update()
    {
        transform.up = RotateTowardsMouse();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        h = Mathf.Abs(h) > 0 && Mathf.Abs(v) > 0 ? h * 0.7f : h;
        v = Mathf.Abs(h) > 0 && Mathf.Abs(v) > 0 ? v * 0.7f : v;
        
        rb.position += new Vector2(h * speed, v * speed) * Time.deltaTime;
        rb.velocity = Vector2.zero;
    }

    Vector2 RotateTowardsMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        return direction;
    }
}
