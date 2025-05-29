using UnityEngine;

public class MovimientoBarco : MonoBehaviour
{
    public Transform destino;        // Punto hacia el que se moverá
    public float velocidad = 5f;     // Velocidad del barco
    public bool activarMovimiento = false;

    void Update()
    {
        if (activarMovimiento && destino != null)
        {
            // Mueve el barco suavemente hacia el destino
            transform.position = Vector3.MoveTowards(transform.position, destino.position, velocidad * Time.deltaTime);

            // Rota el barco hacia la dirección de destino
            Vector3 direccion = destino.position - transform.position;
            direccion.y = 0; // mantén nivelado
            if (direccion != Vector3.zero)
            {
                Quaternion rotacion = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacion, Time.deltaTime * 2f);
            }
        }
    }

    // Llamar esta función desde otro script o trigger
    public void Activar()
    {
        activarMovimiento = true;
    }
}
