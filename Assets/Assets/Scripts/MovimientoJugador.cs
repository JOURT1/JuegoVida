using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float rotacion = 200f;
    public float fuerzaSalto = 5f;

    private Rigidbody rb;
    private Animator animator;
    private bool enSuelo = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        float mov = inputVertical * velocidad * Time.fixedDeltaTime;
        float giro = inputHorizontal * rotacion * Time.fixedDeltaTime;

        // Movimiento hacia adelante/atrás
        Vector3 movimiento = transform.forward * mov;
        rb.MovePosition(rb.position + movimiento);

        // Rotación
        Quaternion rotacionNueva = Quaternion.Euler(0f, giro, 0f);
        rb.MoveRotation(rb.rotation * rotacionNueva);

        // Parámetro para animación (Idle vs Walk)
        float velocidadMovimiento = new Vector2(inputHorizontal, inputVertical).magnitude;
        animator.SetFloat("Speed", velocidadMovimiento, 0, Time.deltaTime);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            animator.SetTrigger("Jump");
            enSuelo = false;
        }
    }

    // Verifica si está tocando el suelo
    void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts.Length > 0 && collision.contacts[0].normal.y > 0.5f)
        {
            enSuelo = true;
        }
    }
}
