using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        Mathf.Clamp(horizontal, -maxSpeed, maxSpeed);
        rb.AddForce(new Vector2(horizontal, 0.0f), ForceMode2D.Impulse);
        Debug.Log($"Current speed: {horizontal}");
    }
}
