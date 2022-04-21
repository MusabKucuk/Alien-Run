using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 50;
    private Texts text;
    private Controller controller;
    private CharacterCombat characterCombat;
    public GameObject avatar;
    private float speed = 15f;
    private float position;

    private void Awake()
    {
        GameObject avatar = GameObject.FindWithTag("Green Player");
        text = avatar.GetComponent<Texts>();
        controller = avatar.GetComponent<Controller>();
        characterCombat = avatar.GetComponent<CharacterCombat>();
    }

    private void Start()
    {
        if (controller.direction == Controller.chracterDirection.left)
        {
            rb.velocity = transform.right * -speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }

        position = transform.position.x;
    }

    private void Update()
    {
        if (position + 12 < gameObject.transform.position.x)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);

        if (collision.GetComponent<Health>() != null)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Tween textFade = text.scoreText.DOFade(1f, 0.4f);
            text.score += characterCombat.score;
            text.scoreText.text = "Score: " + text.score.ToString("0");
            textFade.OnComplete(() => text.scoreText.DOFade(0.35f, 0.4f));
            characterCombat.score *= 1.03f;
        }      
    }
}
