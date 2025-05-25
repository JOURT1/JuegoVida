using UnityEngine;
using TMPro;

public class PistaInteractuable : MonoBehaviour
{
    [Header("Referencias de UI")]
    public GameObject textoInteraccion;
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;

    [Header("Mensaje de la Pista")]
    [TextArea(3, 5)]
    public string mensajePista = "Aquí va el mensaje de la pista.";

    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

    void Start()
    {
        if (textoInteraccion != null) textoInteraccion.SetActive(false);
        if (panelDialogo != null) panelDialogo.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            if (textoInteraccion != null) textoInteraccion.SetActive(false);
            MostrarMensaje();
        }

        if (dialogoActivo && Input.GetKeyDown(KeyCode.F))
        {
            OcultarMensaje();
        }
    }

    void MostrarMensaje()
    {
        if (panelDialogo != null && textoDialogo != null)
        {
            panelDialogo.SetActive(true);
            textoDialogo.text = mensajePista;
            dialogoActivo = true;
        }
    }

    void OcultarMensaje()
    {
        if (panelDialogo != null)
        {
            panelDialogo.SetActive(false);
            dialogoActivo = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            if (textoInteraccion != null) textoInteraccion.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            if (textoInteraccion != null) textoInteraccion.SetActive(false);
        }
    }
}
