using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Chracter : MonoBehaviour
{
    private CharacterCombat characterCombat;
    private Controller controller;
    private AnimationController animationController;
    private IsDead isDead;
    private AudioController audioController;

    private void Awake()
    {
        characterCombat = GetComponent<CharacterCombat>();
        controller = GetComponent<Controller>();
        animationController = GetComponent<AnimationController>();
        isDead = GetComponent<IsDead>();
        audioController = GetComponent<AudioController>();
    }

    private void FixedUpdate()
    {       
       StartCoroutine(isDead.CharacterDead());
    }

    private void Update()
    {
        ApplyFire();
    }


    public void ApplyFire()
    {
        if ( CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        if (characterCombat.isFiring) yield break;
        characterCombat.isFiring = true;
        controller.characterStates = Controller.States.Fire;
        animationController.PlayFireAnim();

        yield return new WaitForSeconds(0.08f);

        audioController.playFireSound();
        characterCombat.DamageGiven();

        yield return new WaitForSeconds(0.2f);
        characterCombat.isFiring = false;

        yield break;
    }

}
