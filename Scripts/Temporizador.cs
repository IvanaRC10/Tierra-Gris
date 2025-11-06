using UnityEngine;
using TMPro; // Para usar TextMeshPro

public class Temporizador : MonoBehaviour
{
    [Header("⏱️ Configuración de tiempo")]
    public float tiempoTotal = 40f; // Tiempo límite del juego
    private float tiempoRestante;

    [Header("🎮 Referencias UI")]
    public TextMeshProUGUI textoTiempo; // Texto que muestra el tiempo
    public TextMeshProUGUI textoFin;    // Texto que mostrará "Fin del juego"

    [Header("🧴 Botellas recolectadas")]
    public int botellasRecolectadas = 0;
    public int botellasNecesarias = 4;

    private bool juegoTerminado = false;

    void Start()
    {
        tiempoRestante = tiempoTotal;
        textoFin.gameObject.SetActive(false);
    }

    void Update()
    {
        if (juegoTerminado) return;

        // Resta el tiempo
        tiempoRestante -= Time.deltaTime;

        // Actualiza el texto del temporizador
        textoTiempo.text = "⏰ Tiempo: " + Mathf.CeilToInt(tiempoRestante).ToString();

        // Si el tiempo llega a cero
        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            FinDelJuego();
        }
    }

    void FinDelJuego()
    {
        juegoTerminado = true;
        textoFin.gameObject.SetActive(true);

        // Verificamos si recolectó todas las botellas
        if (botellasRecolectadas >= botellasNecesarias)
        {
            textoFin.text = "Felicidades! Has ganado";
        }
        else
        {
            textoFin.text = "Lo siento, no has podido recolectar las 4 botellas";
        }

        // Espera un poco antes de pausar el juego (para que el texto aparezca)
        Invoke(nameof(PausarJuego), 0.2f);
    }

    void PausarJuego()
    {
        Time.timeScale = 0f;
    }

    // ✅ FUNCIÓN para sumar botellas (por si la llamas desde otro script)
    public void SumarBotella()
    {
        botellasRecolectadas++;
    }
}