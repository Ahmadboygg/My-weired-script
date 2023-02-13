using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField]private AudioSource hitSoundEffect;
    [SerializeField]private LayerMask bulletLayer;
    [SerializeField]private int maxHealth;
    [SerializeField]private GameObject destroyEffect;
    private int currentHealth;
    private PlayerAnimator playerAnimator;

    void Start() 
    {
        currentHealth = maxHealth;
        playerAnimator = GetComponent<PlayerAnimator>();
    }

    public void TakeDamage(int value)
    {
        hitSoundEffect.Play();
        currentHealth -= value;

        if(currentHealth <= 0)
        {
            Invoke("DestroyEffect",0.1f);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void DestroyEffect()
    {
        if(destroyEffect != null)
        {
            Instantiate(destroyEffect,transform.position,transform.rotation);
            Invoke("DestroyObject",0.1f);
        }
        else
        {
            Invoke("DestroyObject",0.1f);
        }
    }
}
