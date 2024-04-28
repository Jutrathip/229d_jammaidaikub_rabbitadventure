using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Reference to the projectile prefab (e.g., bullet or laser)
    public GameObject projectilePrefab;

    // Time it takes for the projectile to reach the target point (in seconds)
    public float projectileTimeToTarget = 2f;

    // Cooldown time between shots (in seconds)
    public float fireRate = 0.5f;

    // Time of the last shot
    private float lastFireTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // Check if the fire button (usually spacebar or left mouse button) is pressed
        if (Input.GetButtonDown("Fire1") && Time.time >= lastFireTime + fireRate)
        {
            // Calculate the target point based on the mouse position in world coordinates
            Vector2 targetPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Call the Shoot method to fire a projectile toward the target point
            Shoot(targetPoint);

            // Update the last fire time
            lastFireTime = Time.time;
        }
    }

    // Method to shoot a projectile toward a target point
    void Shoot(Vector2 targetPoint)
    {
        // Instantiate the projectile at the player's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the initial velocity using the CalculateProjectile function
        Vector2 initialVelocity = CalculateProjectile(transform.position, targetPoint, projectileTimeToTarget);

        // Add velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = initialVelocity;

        // Destroy the projectile after a certain time to avoid clutter
        Destroy(projectile, projectileTimeToTarget + 1f);
    }

    // Function to calculate initial velocity for a projectile to reach a target point in a given time
    Vector2 CalculateProjectile(Vector2 origin, Vector2 targetPoint, float time)
    {
        // Calculate the distance between the origin and target point
        Vector2 distance = targetPoint - origin;

        // Calculate the initial velocities in the x and y directions
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        // Create a Vector2 with the calculated velocities
        return new Vector2(velocityX, velocityY);
    }
}
