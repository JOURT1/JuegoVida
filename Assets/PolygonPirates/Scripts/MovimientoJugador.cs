using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;
    public float rotacion = 200f;

    void Update()
    {
        float mov = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;
        float giro = Input.GetAxis("Horizontal") * rotacion * Time.deltaTime;

        transform.Translate(0, 0, mov);
        transform.Rotate(0, giro, 0);
    }
}
