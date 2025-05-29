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
    private bool cursorLocked = false;

    void Update()
    {
        // Detectar clic izquierdo para bloquear y ocultar el cursor
        if (Input.GetMouseButtonDown(0) && !cursorLocked)
        {
            LockCursor();
        }

        // No mover ni rotar si el cursor está libre
        if (!cursorLocked) return;

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        // Movimiento
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * y + transform.right * x;
        transform.Translate(moveDirection * runspeed * Time.deltaTime, Space.World);

        // Animación
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cursorLocked = true;
    }
}
