using UnityEngine;
using DG.Tweening;

public class CharacterCombat : MonoBehaviour
{
    public int damage;

    public bool isFiring = false;

    public GameObject attackPoint, attackPoint1;
    public LayerMask targetLayer;
    public GameObject bullet;
    public Transform bulletPosition;
    public float score = 20f;
    Collider2D[] hitResults;
    RaycastHit2D hit;

    private Controller controller;

    private void Awake()
    {
        controller = GetComponent<Controller>();
    }

    public void DamageGiven()
    {

        switch (controller.characterStates)
        {
            case Controller.States.Fire:
                Instantiate(bullet, bulletPosition.position, bulletPosition.rotation);
                break;

            default:
                break;
        }
    }

    public void DamageBehind()
    {
        hitResults = Physics2D.OverlapAreaAll(attackPoint1.transform.position, transform.position, targetLayer);

        foreach (Collider2D hit in hitResults)
        {
            if (hit.GetComponent<Health>() != null)
            {
                hit.GetComponent<Health>().TakeDamage(damage);
                Tween textFade = GetComponent<Texts>().scoreText.DOFade(1f, 0.4f);
                GetComponent<Texts>().score += score;
                GetComponent<Texts>().scoreText.text = "Score: " + GetComponent<Texts>().score.ToString("0");
                textFade.OnComplete(() => GetComponent<Texts>().scoreText.DOFade(0.35f, 0.4f));
                score *= 1.05f;
            }
        }
    }
    private void FixedUpdate()
    {
        DamageBehind();
    }
}
