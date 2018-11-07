using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    private Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {//Comprobamos que tecla se pulsa y le damos la animacion
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
            animator.SetTrigger("mvLeft");
            }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("mvRight");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
        

    }
}
