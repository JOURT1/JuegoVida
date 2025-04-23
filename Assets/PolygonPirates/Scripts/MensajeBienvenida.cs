using UnityEngine;
using TMPro;

public class MensajeBienvenida : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo;

    void Start()
    {
        // Mostrar cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Mostrar panel y mensaje de bienvenida
        if (panelDialogo != null)
            panelDialogo.SetActive(true);

        if (textoDialogo != null)
        {
            textoDialogo.text =
                "¡Bienvenido, aventurero!\n\n" +
                "Te encuentras en la isla de los secretos, donde nada es lo que parece...\n\n" +
                "Interactúa con personajes, objetos y pistas presionando la tecla 'E'.\n" +
                "Tu misión: ¡encontrar el tesoro perdido del gobernador!";
        }
    }
}
