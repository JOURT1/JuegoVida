using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    public float runspeed = 5;
    public float mouseSensitivity = 500f;

    public Animator animator;
    public Transform cameraTransform;

    private float x, y;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //  Oculta el cursor
    }

    void Update()
    {
        //  Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotación vertical de la cámara (mirar arriba/abajo)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotación horizontal del personaje (girar con el mouse)
        transform.Rotate(Vector3.up * mouseX);

        //  Movimiento con teclado
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * y + transform.right * x;
        transform.Translate(moveDirection * runspeed * Time.deltaTime, Space.World);

        //  Animación
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }
}
