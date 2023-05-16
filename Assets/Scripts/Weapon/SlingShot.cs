using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShot : Weapon
{
    public GameObject projectilePrefab;

    public override void Attack()
    {
        Debug.Log("Attack Clicked");
        if (canAttack)
        {
            Debug.Log("Attacking");
            EnableWeapon();
            boxCollider.enabled = true;
            Invoke(nameof(DisableWeapon), attackDuration);
            Invoke(nameof(AttackReset), (60f / attackRate));

            // Create a new instance of the projectile prefab and set its position and rotation to match the slingshot.

            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);

            // Get the Projectile component on the new object
            Projectile projectileScript = projectilePrefab.GetComponent<Projectile>();

            // Set the damage and speed of the projectile
            projectileScript.damage = damage;
            projectileScript.speed = 10f;

        }
    }

}
