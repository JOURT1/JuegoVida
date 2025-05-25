using System.IO;
using UnityEngine;
using TMPro;

public class CofreInteractuar : MonoBehaviour
{
    public GameObject panelInteraccion;
    public TMP_Text mensajeTexto;
    private bool jugadorCerca = false;

    void Start()
    {
        panelInteraccion.SetActive(false);
    }

    void Update()
    {
        if (jugadorCerca)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelInteraccion.SetActive(true);
                mensajeTexto.text = "¡Has encontrado el cofre!\nPresiona F para descargar el certificado.";
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                DescargarCertificado();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            mensajeTexto.text = "Presiona E para interactuar";
            panelInteraccion.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            panelInteraccion.SetActive(false);
        }
    }

    public void DescargarCertificado()
    {
        string rutaCertificado = Path.Combine(Application.streamingAssetsPath, "certificado.pdf");

        if (!File.Exists(rutaCertificado))
        {
            mensajeTexto.text = "❌ No se encontró el certificado en StreamingAssets.";
            return;
        }

        string rutaDescargas = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile), "Downloads");
        string destino = Path.Combine(rutaDescargas, "certificado.pdf");

        try
        {
            File.Copy(rutaCertificado, destino, true);
            Application.OpenURL("file://" + destino);
            mensajeTexto.text = "✅ Certificado guardado en Descargas.";
        }
        catch (System.Exception)
        {
            mensajeTexto.text = "❌ Ocurrió un error al guardar el certificado.";
        }
    }
}
