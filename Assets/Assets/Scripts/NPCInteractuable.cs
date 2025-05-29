﻿using UnityEngine;
using TMPro;

public class NPCInteractuable : MonoBehaviour
{
    public GameObject textoInteraccion;
    public GameObject panelDialogo;
    public TMP_Text textoDialogo;
    public string pista = "Bajo las tablas, el mar susurra. Sigue la sombra que se esconde donde el sol no alcanza.\r\n";
    private Animator animator;
    private bool jugadorCerca = false;
    private bool dialogoActivo = false;

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
            animator.SetTrigger("Hablar");
            MostrarPista();
        }

        if (dialogoActivo && Input.GetKeyDown(KeyCode.F))
        {
            CerrarDialogo();
        }
    }

    void MostrarPista()
    {
        panelDialogo.SetActive(true);
        textoDialogo.text = pista;
        dialogoActivo = true;  // Activamos el estado para cerrar con F
    }

    void CerrarDialogo()
    {
        panelDialogo.SetActive(false);
        dialogoActivo = false;  // Desactivamos el estado
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