using UnityEngine;
using TMPro;

public class MapaInteractuable : MonoBehaviour
{
    public GameObject textoInteraccion;
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;
    [TextArea(3, 5)]
    public string mensajeEncriptado = "Donde la sombra del árbol besa la arena, descansa una pista olvidada. Escucha el susurro del viento entre las hojas, pues allí yace lo que buscas.";

    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

    void Start()
    {
        textoInteraccion.SetActive(false);
        panelDialogo.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            textoInteraccion.SetActive(false);
            MostrarMensaje();
        }

        if (dialogoActivo && Input.GetKeyDown(KeyCode.F))
        {
            OcultarMensaje();
        }
    }

    void MostrarMensaje()
    {
        panelDialogo.SetActive(true);
        textoDialogo.text = mensajeEncriptado;
        dialogoActivo = true;
    }

    void OcultarMensaje()
    {
        panelDialogo.SetActive(false);
        dialogoActivo = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
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
