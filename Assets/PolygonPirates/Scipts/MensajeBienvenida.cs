using UnityEngine;
using TMPro;

public class MensajeBienvenida : MonoBehaviour
{
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;

    void Start()
    {
        // Mensaje inicial
        string mensaje =
        "¡Bienvenido, aventurero!\n\n" +
        "Te encuentras en la isla de los secretos, donde nada es lo que parece...\n\n" +
        "Interactúa con personajes, objetos y pistas presionando la tecla 'E'.\n" +
        "Tu misión: ¡encontrar el tesoro perdido del gobernador!";


        // Mostrar mensaje
        panelDialogo.SetActive(true);
        textoDialogo.text = mensaje;

    }

    void OcultarMensaje()
    {
        panelDialogo.SetActive(false);
    }
    public void CerrarMensaje()
    {
        panelDialogo.SetActive(false);
    }

}
