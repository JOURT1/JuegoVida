using UnityEngine;
using TMPro;

public class ControlTimon : MonoBehaviour
{
    public GameObject textoInteraccion;
    public GameObject barco;
    public GameObject jugador;
    public Transform puntoManejo; // punto donde el jugador se posiciona al manejar
    private bool jugadorCerca = false;
    private bool manejando = false;

    private MovimientoJugador movimientoJugador;
    private Rigidbody rbBarco;

    void Start()
    {
        textoInteraccion.SetActive(false);
        movimientoJugador = jugador.GetComponent<MovimientoJugador>();
        rbBarco = barco.GetComponent<Rigidbody>();
        rbBarco.isKinematic = true; // para que no se mueva sin control
    }

    void Update()
    {
        if (jugadorCerca && !manejando && Input.GetKeyDown(KeyCode.E))
        {
            EntrarManejo();
        }

        if (manejando && Input.GetKeyDown(KeyCode.F))
        {
            SalirManejo();
        }

        if (manejando)
        {
            float direccion = Input.GetAxis("Horizontal");
            float avance = Input.GetAxis("Vertical");

            // Movimiento simple del barco (ajusta según tu lógica)
            rbBarco.MoveRotation(rbBarco.rotation * Quaternion.Euler(0, direccion * 0.5f, 0));
            rbBarco.MovePosition(barco.transform.position + barco.transform.forward * avance * Time.deltaTime * 2f);
        }
    }

    void EntrarManejo()
    {
        manejando = true;
        textoInteraccion.SetActive(false);
        movimientoJugador.enabled = false;

        // Posicionar al jugador en el timón
        jugador.transform.position = puntoManejo.position;
        jugador.transform.rotation = puntoManejo.rotation;

        rbBarco.isKinematic = false; // Activar control físico del barco
    }

    void SalirManejo()
    {
        manejando = false;
        movimientoJugador.enabled = true;
        rbBarco.isKinematic = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            if (!manejando)
                textoInteraccion.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            textoInteraccion.SetActive(false);
        }
    }
}
