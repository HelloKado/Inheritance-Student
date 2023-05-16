using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeapon : Weapon
{
    public float swingSpeed;
    public float swingDegrees;

    public override void Attack()
    {
        //starts attack
        Invoke("AttackReset", 60f / attackRate);
        //rotate to starting position
        transform.localEulerAngles = new Vector3(0, 0, -swingDegrees);
        //turn on the weapon
        EnableWeapon();
        //swing down
        StartCoroutine(Swing());
        //disable weapon

    }

    IEnumerator Swing()
    {
        float degrees = 0f;

        while (degrees < swingDegrees * 2)
        {
            transform.Rotate(Vector3.forward, swingSpeed * Time.deltaTime);
            degrees += swingSpeed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        DisableWeapon();
    }
}
