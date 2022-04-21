using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public Transform cam;

    float position;
    float speed = 0.5f;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MeteorMovement();
    }

    private void MeteorMovement()
    {
        position = cam.transform.position.x - transform.position.x;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (speed > 0) speed = Random.Range(0.5f, 1f);

        if (position <= 11 && position >= 7.5f)
        {
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
            position = cam.transform.position.x - transform.position.x;
        }
        else
        {
            speed *= -1;
            rigidBody.velocity = new Vector2(-speed, rigidBody.velocity.y);
        }
    }
}
