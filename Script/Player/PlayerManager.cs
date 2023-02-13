using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private PlayerControl playerControl;
    private PlayerAnimator playerAnimator;
    private Bullet bullet;
    [SerializeField]private Transform bulletPoint;
    private bool isDeadZone = false;
    [SerializeField]private LayerMask platformLayer;
    [SerializeField]private GameObject bulletObject;
    [SerializeField]private GameObject muzzleEffect;
    [SerializeField]private AudioSource shootSoundEffect;
    private CharacterStat characterStat;

    public float movementSpeed;
    public float jumpPower;

    public float shootSpeed;
    private bool isDead;
    private float currentShootSpeed;

    void Start()
    {
        isDead = false;
        bullet = GetComponent<Bullet>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerControl = GetComponent<PlayerControl>();
        playerAnimator = GetComponent<PlayerAnimator>();
        characterStat = GetComponent<CharacterStat>();
    }

    void Update()
    {
        if(isDead)
        {
            playerAnimator.DeadAnimator(true);
            playerAnimator.MoveAnimator(false);
            playerAnimator.JumpAnimator(false);
            playerAnimator.CrouchAnimator(false);
        }
        else
        {
            //check if player isGrounded
            RaycastHit2D isGrounded = Physics2D.Raycast(transform.position,Vector2.down,0.2f,platformLayer);
            if(isGrounded.collider != null)
            {
                Debug.DrawRay(transform.position,new Vector2(0,-0.2f),Color.red);

                //check if player on dead line

                if(isGrounded.collider.gameObject.CompareTag("Dead Line"))
                {
                    characterStat.TakeDamage(10);
                }
                else
                {
                    //player jump control 

                    if(playerControl.jump)
                    {
                        PlayerJump(jumpPower);
                        playerAnimator.JumpAnimator(true);
                    }
                    else
                    {
                        playerAnimator.JumpAnimator(false);
                    }

                    //player crouch control

                    if(playerControl.crouch)
                    {
                        PlayerCrouch();
                        playerAnimator.CrouchAnimator(true);

                        //check if player move control is pressed in crouch position
                        //player should be crouch position and just rotate if press move control

                        if(playerControl.moveRight)
                        {
                            PlayerRotate(false);
                            playerAnimator.MoveAnimator(false);
                        }
                        else if(playerControl.moveLeft)
                        {
                            PlayerRotate(true);
                            playerAnimator.MoveAnimator(false);
                        }
                    }
                    else
                    {
                        playerAnimator.CrouchAnimator(false);

                        //check if player move control is pressed out of crouch position
                        //player should be move position and rotate if press move control

                        if(playerControl.moveLeft)
                        {
                            PlayerMove(-movementSpeed);
                            playerAnimator.MoveAnimator(true);
                            PlayerRotate(true);
                        }
                        else if(playerControl.moveRight)
                        {
                            PlayerMove(movementSpeed);
                            playerAnimator.MoveAnimator(true);
                            PlayerRotate(false);
                        }
                        else
                        {
                            PlayerMove(0);
                            playerAnimator.MoveAnimator(false);
                        }
                    }

                    //player shoot control
                    if(currentShootSpeed <= 0)
                    {
                        if(playerControl.shoot)
                        {
                            PlayerShoot();
                            MuzzleEffect();
                            currentShootSpeed = shootSpeed;
                        }
                    }
                    else
                    {
                        currentShootSpeed -= Time.deltaTime;
                    }
                }
            }
            else
            {
                // move control in air
                if(playerControl.moveRight)
                {
                    PlayerMove(movementSpeed);
                    PlayerRotate(false);
                }
                else if (playerControl.moveLeft)
                {
                    PlayerMove(-movementSpeed);
                    PlayerRotate(true);
                }

                if(currentShootSpeed <= 0)
                {
                    if(playerControl.shoot)
                    {
                        PlayerShoot();
                        MuzzleEffect();
                        currentShootSpeed = shootSpeed;
                    }
                }
                else
                {
                    currentShootSpeed -= Time.deltaTime;
                }

                Debug.DrawRay(transform.position,new Vector2(0,-0.2f),Color.green);
            }
        }
        
    }

    private void PlayerJump(float value)
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.y,value);
    }
    
    private void PlayerCrouch()
    {
        rigidbody2D.velocity = new Vector2(0,0);
    }

    public void PlayerDead()
    {
        isDead = true;
        currentShootSpeed = shootSpeed;
        jumpPower = 0;
        movementSpeed = 0;
        rigidbody2D.velocity = new Vector2(0,0);
        playerAnimator.DeadAnimator(true);
        Invoke("PlayerDestroy", 1.8f);
    }

    public void PlayerMove(float value)
    {
        rigidbody2D.velocity = new Vector2(value,rigidbody2D.velocity.y);
    }

    private void PlayerRotate(bool value)
    {
        if(value)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }

    private void PlayerShoot()
    {
        Instantiate(bulletObject,bulletPoint.position,bulletPoint.rotation);
        shootSoundEffect.Play();
    }

    private void MuzzleEffect()
    {
        Instantiate(muzzleEffect,bulletPoint);
        shootSoundEffect.Play();
    }

    private void PlayerDestroy()
    {
        Destroy(gameObject);
    }
}
