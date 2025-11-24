using UnityEngine;

public class SeguirCamaraJugador : MonoBehaviour
{
    public Transform jugador;       // Arrastra tu GameObject de Jugador aquí desde el Inspector
    public float suavidadCamara = 0.125f;  // Controla qué tan "suave" sigue la cámara al jugador
    public Vector3 offset;          // Desplazamiento de la cámara (ej: para que el jugador no esté justo en el centro)

    void LateUpdate() // Se llama después de que todos los Updates se han ejecutado
    {
        if (jugador == null) return; // Si no hay jugador asignado, no hagas nada

        // Calcula la posición deseada de la cámara
        Vector3 posicionDeseada = jugador.position + offset;

        // Suaviza el movimiento de la cámara para que no sea tan brusco
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, suavidadCamara);

        // Asigna la nueva posición a la cámara, manteniendo la profundidad (z)
        transform.position = new Vector3(
            posicionSuavizada.x,
            posicionSuavizada.y,
            transform.position.z
        );
    }
}
