using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float rotacion = 200f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float mov = Input.GetAxis("Vertical") * velocidad * Time.fixedDeltaTime;
        float giro = Input.GetAxis("Horizontal") * rotacion * Time.fixedDeltaTime;

        // Movimiento hacia adelante/atrás
        Vector3 movimiento = transform.forward * mov;
        rb.MovePosition(rb.position + movimiento);

        // Rotación
        Quaternion rotacionNueva = Quaternion.Euler(0f, giro, 0f);
        rb.MoveRotation(rb.rotation * rotacionNueva);
    }
}
