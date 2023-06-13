using UnityEngine;

public class MovimientoObjeto : MonoBehaviour
{
    public float velocidad = 5f;
    public float sensibilidadRaton = 3f;

    private CharacterController characterController;
    private bool rotando = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtener la entrada del teclado
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Obtener la dirección hacia adelante del jugador
        Vector3 direccionJugador = transform.forward;

        // Obtener la dirección hacia los lados del jugador
        Vector3 direccionLateral = transform.right;

        // Calcular la dirección del movimiento
        Vector3 direccion = (direccionJugador * movimientoVertical) + (direccionLateral * movimientoHorizontal);

        // Normalizar la dirección para mantener una velocidad constante en todas las direcciones diagonales
        direccion.Normalize();

        // Calcular la velocidad basada en la dirección y la velocidad
        Vector3 velocidadMovimiento = direccion * velocidad;

        // Mover el objeto utilizando CharacterController
        characterController.SimpleMove(velocidadMovimiento);

        // Girar la cámara con el ratón al hacer clic derecho
        if (Input.GetMouseButtonDown(1))
        {
            rotando = true;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetMouseButtonUp(1))
        {
            rotando = false;
            Cursor.lockState = CursorLockMode.None;
        }

        if (rotando)
        {
            float rotacionHorizontal = Input.GetAxis("Mouse X") * sensibilidadRaton;
            transform.Rotate(0f, rotacionHorizontal, 0f);
        }
    }
}

