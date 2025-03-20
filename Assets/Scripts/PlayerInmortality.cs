using UnityEngine;
using System.Collections;

public class PlayerImmortality : MonoBehaviour
{
    public enum PlayerState { Normal, Immortal, Escaping } // Ahora incluye "Escaping"
    public PlayerState currentState = PlayerState.Normal; // Estado actual

    private Renderer playerRenderer;
    private Color originalColor;

    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InmortalPoint")) // Si toca el InmortalPoint
        {
            StartCoroutine(BecomeImmortal());
            Destroy(other.gameObject); // Elimina el objeto tras tocarlo
        }
    }

    IEnumerator BecomeImmortal()
    {
        currentState = PlayerState.Immortal; // Cambia estado a Inmortal
        playerRenderer.material.color = Color.yellow; // Indicador visual
        yield return new WaitForSeconds(7); // Espera 7 segundos
        currentState = PlayerState.Normal; // Vuelve a estado Normal
        playerRenderer.material.color = originalColor; // Restaura color original
    }

    // Método para cambiar al estado "Escapando" 
    public void StartEscaping()
    {
        currentState = PlayerState.Escaping;
        GetComponent<PlayerController>().speed = 10;
        playerRenderer.material.color = Color.red; // Cambiar color cuando está escapando
    }

    // Método para volver al estado normal
    public void StopEscaping()
    {
        currentState = PlayerState.Normal;
        playerRenderer.material.color = originalColor; // Restaura color original
    }
}
