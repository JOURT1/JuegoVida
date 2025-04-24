using UnityEngine;

public class BotonContinuar : MonoBehaviour
{
    public GameObject panelDialogo;

    public void AlPresionarContinuar()
    {
        // Ocultar el panel de bienvenida
        if (panelDialogo != null)
            panelDialogo.SetActive(false);

        // Bloquear el cursor y ocultarlo para jugar normalmente
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
