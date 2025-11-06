using UnityEngine;

public class BotellaScript : MonoBehaviour
{
    // Cuánto de vida aumenta la botella (0.1f = 10% de vida)
    public float vidaRestaurada = 0.2f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 1️⃣ Verificamos que el objeto que colisiona sea el jugador.
        if (other.CompareTag("Player"))
        {
            // 2️⃣ Intentamos obtener el script 'BarraVida'
            BarraVida barraVida = FindObjectOfType<BarraVida>();

            if (barraVida != null)
            {
                // Aumentar vida del jugador
                barraVida.AumentarVida(vidaRestaurada);
            }
            else
            {
                Debug.LogError("🔴 ERROR: No se encontró el script 'BarraVida' en la escena. ¿Está activo?");
            }

            // 3️⃣ Sumamos una botella al contador del temporizador (usando la función correcta)
            Temporizador temporizador = FindObjectOfType<Temporizador>();
            if (temporizador != null)
            {
                temporizador.SumarBotella(); // ✅ Llamamos al método en lugar de acceder a la variable
            }
            else
            {
                Debug.LogError("⚠️ No se encontró el script 'Temporizador' en la escena.");
            }

            // 4️⃣ Destruir la botella después de recogerla
            Destroy(gameObject);
        }
    }
}