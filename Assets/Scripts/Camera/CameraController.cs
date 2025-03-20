using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Objeto que representa al player
    public GameObject player;
    // Distancia entre la cámara y el player
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // Calculamos el offset entre la cámara y el jugador para mantener la distancia constante
        offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // La cámara sigue al jugador, pero mantiene su offset, sin movimiento con el ratón
        transform.position = player.transform.position + offset;
    }
}

