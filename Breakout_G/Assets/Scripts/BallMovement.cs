using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gameManager;
    private bool firstTouch;
    [SerializeField] private float ballSpeed = 1f;
    [SerializeField] private float maxBallSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        firstTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstTouch)
        {
            rb.AddForce(new Vector2(rb.velocity.x, -ballSpeed * Time.deltaTime), ForceMode2D.Impulse);
        }
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxBallSpeed, maxBallSpeed), Mathf.Clamp(rb.velocity.y, -maxBallSpeed, maxBallSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        firstTouch = true;

        if (collision.gameObject.tag == "Player" && rb.velocity.y >= collision.rigidbody.velocity.y)
        {
            float hitX = (rb.position.x - collision.rigidbody.position.x) / collision.collider.bounds.size.x;
            Vector2 direction = new Vector2(hitX, 1).normalized;

            rb.velocity = direction * ballSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.GameOver();
    }
}
