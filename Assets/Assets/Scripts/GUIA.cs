using UnityEngine;
using TMPro;

public class GUIA: MonoBehaviour
{
    public Transform[] puntosDestino;          // Lista de destinos
    public Transform jugador;                  // Referencia al jugador
    public Transform flecha;                   // Flecha 3D
    public TextMeshProUGUI textoAyuda;         // Texto en pantalla
    public float distanciaMinima = 2f;         // Cuándo considerar que llegó

    private int indiceActual = 0;              // Índice del punto actual
    private bool flechaVisible = false;        // Control si está visible

    void Start()
    {
        flecha.gameObject.SetActive(false);    // Ocultar al inicio
        textoAyuda.text = "Presiona H para mostrar la flecha";
    }

    void Update()
    {
        // Activar flecha solo si se presiona H y aún hay puntos
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (indiceActual < puntosDestino.Length)
            {
                flechaVisible = true;
                flecha.gameObject.SetActive(true);
            }
        }

        // Si la flecha no está visible o ya se terminó la lista, no hacer nada
        if (!flechaVisible || indiceActual >= puntosDestino.Length) return;

        // Dirección hacia el destino
        Vector3 direccion = puntosDestino[indiceActual].position - jugador.position;
        direccion.y = 0;

        if (direccion != Vector3.zero)
        {
            flecha.rotation = Quaternion.LookRotation(direccion);
        }

        // Verificar si llegó al punto
        if (direccion.magnitude < distanciaMinima)
        {
            // Ocultar flecha y esperar otra pulsación de H
            flechaVisible = false;
            flecha.gameObject.SetActive(false);
            indiceActual++;
        }
    }
}
