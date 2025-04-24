using UnityEngine;

public class CamaraTerceraPersona : MonoBehaviour
{
    public Transform objetivo; // jugador
    public Vector3 offset = new Vector3(0f, 2f, -5f);
    public float sensibilidadMouseX = 2f;
    public float sensibilidadMouseY = 1f;
    public float distancia = 5f;
    public float altura = 2f;
    public float suavizado = 10f;
    public float minY = -40f;
    public float maxY = 80f;

    private float rotacionY;
    private float rotacionX;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor para rotar con mouse
    }

    void LateUpdate()
    {
        if (objetivo == null) return;

        rotacionY += Input.GetAxis("Mouse X") * sensibilidadMouseX;
        rotacionX -= Input.GetAxis("Mouse Y") * sensibilidadMouseY;
        rotacionX = Mathf.Clamp(rotacionX, minY, maxY);

        Quaternion rotacion = Quaternion.Euler(rotacionX, rotacionY, 0);
        Vector3 posicionDeseada = objetivo.position + rotacion * offset;

        transform.position = Vector3.Lerp(transform.position, posicionDeseada, Time.deltaTime * suavizado);
        transform.LookAt(objetivo.position + Vector3.up * altura);
    }
}
