using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


    public float speed;     //Variable para guardar la velocidad, expuesta en el editor
    public float jumpHeight = 50;
    public bool isGrounded;
    public int count = 0;
    public int life = 0;
    public Text LoseText;
    public Text LifeText;

    private Rigidbody rb;   //Variable donde guardamos una referencia al rigidbody(fisicas) del objeto

	//Ejecucion de la aplicacion
	void Start () {
        rb = GetComponent<Rigidbody>();
        LifeText.text = "";
	}
	
	//Actualizacion del juego por frame
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");     //Variable para coger los inputs del teclado y mover el personaje por el eje horizontal
        float moveVertical = Input.GetAxis("Vertical");         //Variable para coger los inputs del teclado y mover el personaje por el eje vertical

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //Los almacenamos en un vector3

        rb.AddForce(movement * speed);      //Lo multiplicamos por la velocidad
        if (count < 5) {                    //Mientras no haya saltado 5 veces, podra saltar
            if (isGrounded)
            {
                isGrounded = false;
                rb.AddForce(0, jumpHeight, 0, ForceMode.Impulse);
                count++;
            }

        }        
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            life = life - 1;
            setLifeText();
        }
    }

    void setLifeText()
    {
        LifeText.text = "Vida: " + life.ToString();
        if(life>=0)
        {
            LoseText.text = "You Lose";
        }
    }
}

