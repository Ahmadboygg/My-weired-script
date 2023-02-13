using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CloseCredits());
    }
    
    private IEnumerator CloseCredits()
    {
        animator.SetTrigger("PlayOn");
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene("Main Menu");
    }
}
