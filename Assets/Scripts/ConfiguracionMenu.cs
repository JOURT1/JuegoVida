using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ConfiguracionMenu : MonoBehaviour
{
    public TMP_Dropdown resolucionDropdown;
    public TMP_Dropdown calidadDropdown;
    public Toggle pantallaCompletaToggle;
    public Slider brilloSlider;
    public Slider audioSlider;

    private Resolution[] resoluciones;

    void Start()
    {
        // Cargar resoluciones disponibles
        resoluciones = Screen.resolutions;
        resolucionDropdown.ClearOptions();

        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }

        resolucionDropdown.AddOptions(opciones);
        resolucionDropdown.value = resolucionActual;
        resolucionDropdown.RefreshShownValue();

        // Cargar valores iniciales
        pantallaCompletaToggle.isOn = Screen.fullScreen;
        brilloSlider.value = 1f;
        audioSlider.value = AudioListener.volume;

        Debug.Log("✅ Configuración inicial cargada.");
    }

    public void CambiarResolucion(int index)
    {
        if (index >= 0 && index < resoluciones.Length)
        {
            Resolution resolucion = resoluciones[index];
            Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
            Debug.Log("🖥 Resolución cambiada a: " + resolucion.width + "x" + resolucion.height);
        }
    }

    public void CambiarCalidad(int index)
    {
        QualitySettings.SetQualityLevel(index);
        Debug.Log("🎚 Calidad cambiada al nivel: " + index);
    }

    public void CambiarPantallaCompleta(bool esCompleta)
    {
        Screen.fullScreen = esCompleta;
        Debug.Log("🔳 Pantalla completa: " + esCompleta);
    }

    public void CambiarBrillo(float valor)
    {
        RenderSettings.ambientLight = Color.white * valor;
        Debug.Log("🔆 Brillo ajustado a: " + valor);
    }

    public void CambiarVolumen(float volumen)
    {
        AudioListener.volume = volumen;
        Debug.Log("🔊 Volumen ajustado a: " + volumen);
    }

    public void MetodoDePrueba()
    {
        Debug.Log("🧪 Método de prueba ejecutado correctamente.");
    }
}
