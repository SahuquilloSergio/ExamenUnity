using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;   //Variable que hace referencia al jugador

    private Vector3 offset;     //Variable para guardar el offset


	//Codigo que se ejecuta al inicio
	void Start () {
        //Guardamos en offset la distancia entre la camara y el jugador
        offset = transform.position - player.transform.position;
	}
	
	//Actualizacion de la imagen. Usamos el metodo LateUpdate porque queremos que la camara
    //sea lo ultimo en actualizarse
	void LateUpdate () {
        //Le damos a la camara la posicion del jugador mas el offset
        transform.position = player.transform.position + offset;
	}
}
