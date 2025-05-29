using UnityEngine;

public class DetectorSubida : MonoBehaviour
{
    public MovimientoBarco barco;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barco.Activar(); // Activa el movimiento
        }
    }
}
