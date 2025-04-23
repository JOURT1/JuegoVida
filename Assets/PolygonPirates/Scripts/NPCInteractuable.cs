using UnityEngine;
using TMPro;

public class NPCInteractuable : MonoBehaviour
{
    public GameObject textoInteraccion;
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;
    public string pista = "El mar oculta más de lo que muestra. Revisa el fondo...";
    private Animator animator;
    private bool jugadorCerca = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        textoInteraccion.SetActive(false);
        panelDialogo.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            textoInteraccion.SetActive(false);
            animator.SetTrigger("Hablar"); // tu animación debe tener este trigger
            MostrarPista();
        }
    }

    void MostrarPista()
    {
        panelDialogo.SetActive(true);
        textoDialogo.text = pista;
        Invoke("OcultarPista", 5f);
    }

    void OcultarPista()
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
