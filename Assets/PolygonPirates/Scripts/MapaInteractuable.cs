using UnityEngine;
using TMPro;

public class MapaInteractuable : MonoBehaviour
{
    public GameObject textoInteraccion;
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;
    [TextArea(3, 5)]
    public string mensajeEncriptado = "Tres guardianas de hojas ondean solas, donde el horizonte besa lo profundo. Allí duerme lo que dejé atrás.";

    private bool jugadorCerca = false;

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
    }

    void MostrarMensaje()
    {
        panelDialogo.SetActive(true);
        textoDialogo.text = mensajeEncriptado;
        Invoke("OcultarMensaje", 6f);
    }

    void OcultarMensaje()
    {
        panelDialogo.SetActive(false);
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
