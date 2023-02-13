using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMultipleDirection : MonoBehaviour
{
    [SerializeField]private int numberOfBullet;
    [SerializeField]private GameObject bulletProjectile;
    [SerializeField]private float radius;
    [SerializeField]private float bulletSpeed;
    [SerializeField]private Transform bulletPoint;
    [SerializeField]private AudioSource shootSoundEffect;
    private GameObject projectile;
    private Vector2 startPos;

    private float currentShootSpeed;
    [SerializeField]private float shootSpeed;

    void Update()
    {
        Shoot();
    }

    void spawnProjectile(int value)
    {
        float angleStep = 200 / value;
        float angle = 180f;

        for (int i = 0; i <= value -1; i++)
        {
            //posisi X untuk projectileVector
            float projectileDirectionX = startPos.x + Mathf.Sin((angle * Mathf.PI) / 180) * radius;

            //posisi Y untuk projectileVector
            float projectileDirectionY = startPos.y + Mathf.Cos((angle * Mathf.PI) / 180) * radius;

            Vector2 projectileVector = new Vector2(projectileDirectionX,projectileDirectionY);

            //arah projectilenya yaitu dari start pos (x = 0, y= 0) ke arah projectileVector 
            Vector2 projectileMoveDirection = (projectileVector - startPos).normalized * bulletSpeed;

            GameObject projectile = Instantiate(bulletProjectile,startPos,Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x,projectileMoveDirection.y);

            angle += angleStep;
        }
    }

    void Shoot()
    {
        if(currentShootSpeed <=0)
        {
            startPos = bulletPoint.position;
            spawnProjectile(numberOfBullet);
            currentShootSpeed = shootSpeed;
            shootSoundEffect.Play();
        }
        else
        {
            currentShootSpeed -= Time.deltaTime;
        }
    }
}
