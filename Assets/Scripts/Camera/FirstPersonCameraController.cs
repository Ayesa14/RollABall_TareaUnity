using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    // El jugador cuyo movimiento controlará la cámara
    public GameObject player;

    // Sensibilidad del ratón para la rotación horizontal
    public float mouseSensitivity = 2f;

    // Límite para la rotación vertical de la cámara
    public float verticalRotationLimit = 80f;

    private float rotationY = 0f; // Rotación horizontal de la cámara (eje Y)

    // Start is called before the first frame update
    void Start()
    {
        // Configurar el cursor para que esté bloqueado en el centro de la pantalla (modo primera persona)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento horizontal de la cámara (con el ratón)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Actualizamos la rotación horizontal de la cámara
        rotationY += mouseX;

        // Aplicamos la rotación de la cámara alrededor del eje Y
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);

        // La cámara sigue al jugador en las posiciones X y Z, pero no en la Y
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
