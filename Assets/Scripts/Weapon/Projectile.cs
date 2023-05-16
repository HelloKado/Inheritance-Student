using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Variables for damage and speed
    public float damage;
    public float speed;

    // Rigidbody for physics simulation
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component on this object
        rb = GetComponent<Rigidbody2D>();

        // Set the velocity of the Rigidbody2D to move the projectile forward
        rb.velocity = transform.right * speed;
    }

    // OnTriggerEnter2D is called when this object collides with another object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the other object has an Enemy component
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            // Damage the enemy and destroy this object
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}


