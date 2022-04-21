using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    public Transform platform;
    private Health health;

    float speed = 3;
    float position;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
    }

    private void FixedUpdate()
    {
        virusMovement();
    }

    private void virusMovement()
    {
        if (health.health > 0) { 

        position = platform.transform.position.x - transform.position.x;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (speed > 0) speed = Random.Range(1.5f,4f);

        if (position <= 0f && position >= -2.5f)
        {
            
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            position = platform.transform.position.x - transform.position.x;        
        }
        else
        {
            speed *= -1;
            rigidBody.velocity = new Vector2(-speed * 2, rigidBody.velocity.y);

            if (spriteRenderer.flipX == false) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;
        }
      }
    }

}
