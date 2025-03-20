using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject firstPersonCamera;  // Cámara en primera persona
    public GameObject thirdPersonCamera;  // Cámara en tercera persona

    // Start is called before the first frame update
    void Start()
    {
        // Inicialmente, la cámara en tercera persona está activa y la cámara en primera persona está desactivada
        thirdPersonCamera.SetActive(true);
        firstPersonCamera.SetActive(false);  // Asegurarse de que la cámara en primera persona esté desactivada
    }

    // Update is called once per frame
    void Update()
    {
        // Cambiar de cámara al presionar la tecla "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    // Función para alternar entre las cámaras
    void SwitchCamera()
    {
        // Alternar entre las cámaras
        if (firstPersonCamera.activeSelf)
        {
            // Si la cámara en primera persona está activa, desactívala y activa la cámara en tercera persona
            firstPersonCamera.SetActive(false);
            thirdPersonCamera.SetActive(true);
        }
        else
        {
            // Si la cámara en tercera persona está activa, desactívala y activa la cámara en primera persona
            firstPersonCamera.SetActive(true);
            thirdPersonCamera.SetActive(false);
        }
    }
}


