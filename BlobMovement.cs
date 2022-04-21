using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    public Transform platform;
    private Health health;
    private Transform transformOb;


    float speed = 1;
    float position;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Health>();
        transformOb = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        blobMovement();
    }

    private void blobMovement()
    {
        if (health.health > 0)
        {

            position = platform.transform.position.x - transform.position.x;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

            

            if (speed > 0) speed = Random.Range(0.2f, 1f);

            if(transformOb.position.y - platform.position.y < 0.65f) rigidBody.velocity = Vector2.up * 4f;

            if (position <= -0.1f && position >= -2.5f)
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
