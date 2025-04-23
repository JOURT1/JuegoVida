using UnityEngine;

public class CamaraSeguirJugador : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 5, -7);
    public float suavizado = 5f;

    void LateUpdate()
    {
        if (jugador == null) return;

        Vector3 posicionDeseada = jugador.position + offset;
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado * Time.deltaTime);

        transform.LookAt(jugador);
    }
}
