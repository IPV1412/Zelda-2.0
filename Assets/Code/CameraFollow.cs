using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador (asignar desde el inspector)
    public float followSpeed = 1f; // Velocidad de suavizado del movimiento de la cámara

    private Camera mainCamera; // Referencia a la cámara principal
    private float cameraHeight;
    private float cameraWidth;
    private Vector3 targetPosition; // Posición objetivo de la cámara

    void Start()
    {
        mainCamera = Camera.main;

        // Calculamos el alto y ancho total de la cámara en unidades del mundo
        cameraHeight = mainCamera.orthographicSize * 2;
        cameraWidth = cameraHeight * mainCamera.aspect;

        // Inicializamos la posición objetivo de la cámara como la posición actual
        targetPosition = transform.position;
    }

    void Update()
    {
        // Obtener la posición actual del jugador y la cámara
        Vector3 playerPos = player.position;
        Vector3 cameraPos = transform.position;

        // Verificar si el jugador está fuera del límite superior de la cámara
        if (playerPos.y > cameraPos.y + (cameraHeight / 2))
        {
            // Mover la cámara hacia arriba por la altura total de la cámara
            targetPosition.y += cameraHeight;
        }
        // Verificar si el jugador está fuera del límite inferior de la cámara
        else if (playerPos.y < cameraPos.y - (cameraHeight / 2))
        {
            // Mover la cámara hacia abajo por la altura total de la cámara
            targetPosition.y -= cameraHeight;
        }

        // Verificar si el jugador está fuera del límite derecho de la cámara
        if (playerPos.x > cameraPos.x + (cameraWidth / 2))
        {
            // Mover la cámara hacia la derecha por el ancho total de la cámara
            targetPosition.x += cameraWidth;
        }
        // Verificar si el jugador está fuera del límite izquierdo de la cámara
        else if (playerPos.x < cameraPos.x - (cameraWidth / 2))
        {
            // Mover la cámara hacia la izquierda por el ancho total de la cámara
            targetPosition.x -= cameraWidth;
        }

        // Aplicar el movimiento suavizado de la cámara hacia la posición objetivo
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
