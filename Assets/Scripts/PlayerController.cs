using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; 
    private int count; 
    private float movementX;
    private float movementY;

    public float speed = 5.0f; 
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Animator animator;
    public PlayerImmortality playerImmortality;

    // Habilitar o deshabilitar el control por acelerómetro
    public bool useAccelerometer = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        animator = GetComponent<Animator>();
        playerImmortality = GetComponent<PlayerImmortality>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

    private void FixedUpdate() 
    {
        Vector3 movement = Vector3.zero; // Evita acumulación de valores antiguos

        if (useAccelerometer && SystemInfo.supportsAccelerometer)
        {
            // Movimiento con acelerómetro
            movement.x = -Input.acceleration.y;
            movement.z = Input.acceleration.x;

            if (movement.sqrMagnitude > 1)
                movement.Normalize(); 

            movement *= speed;
        }
        else
        {
            // Movimiento con teclado/joystick (usando variables globales)
            movement = new Vector3(movementX, 0.0f, movementY) * speed;
        }

        rb.AddForce(movement);

        // Control de animaciones (si el Animator existe)
        if (animator != null)
        {
            // Si recoge 9 PickUp, entra en estado Escapando
            if (count >= 9) 
            {
                playerImmortality?.StartEscaping(); // Previene error si es null
                animator.SetBool("isEscaping", true);
            }
            else
            {
                animator.SetBool("isEscaping", false);
            }

            // Estado Inmortal (verificación para evitar error)
            if (playerImmortality != null)
            {
                animator.SetBool("isImmortal", playerImmortality.currentState == PlayerImmortality.PlayerState.Immortal);
            }
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject); 
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "Perdiste!";
        }
    }
}