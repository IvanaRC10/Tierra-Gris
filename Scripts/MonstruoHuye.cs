using UnityEngine;

public class MonstruoHuye : MonoBehaviour
{
    public Transform player;
    public float velocidadHuir = 8f;
    public float velocidadNormal = 2f;
    public float distanciaPeligro = 5f;

    private float direccion = 1f; // 1 = derecha, -1 = izquierda

    void Update()
    {
        if (player == null) return;

        float distancia = Vector2.Distance(transform.position, player.position);

        // Si el jugador está cerca, huye
        if (distancia < distanciaPeligro)
        {
            if (player.position.x < transform.position.x)
                direccion = 1f;   // Huir hacia la derecha
            else
                direccion = -1f;  // Huir hacia la izquierda

            transform.position += new Vector3(direccion * velocidadHuir * Time.deltaTime, 0, 0);
        }
        else
        {
            // Camina normal siguiendo el camino
            transform.position += new Vector3(direccion * velocidadNormal * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si choca con un borde del camino, se voltea
        if (collision.CompareTag("Borde"))
        {
            direccion *= -1;
        }
    }
}