using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [Header("Componentes de la barra")]
    public Image relleno; // arrastra aquí la imagen del relleno en el Inspector

    [Header("Estado de vida")]
    [Range(0f, 1f)]
    public float vidaActual = 1f; // valor entre 0 y 1

    void Start()
    {
        ActualizarBarra();
    }

    // 🔹 Aumentar vida (por ejemplo, al tocar una botella)
    public void AumentarVida(float cantidad)
    {
        vidaActual += cantidad;
        vidaActual = Mathf.Clamp01(vidaActual); // evita que pase de 1
        ActualizarBarra();
        Debug.Log("✅ Vida aumentada. Vida actual: " + vidaActual);
    }

    // 🔹 Reducir vida (por ejemplo, al tocar una piedra u obstáculo)
    public void ReducirVida(float cantidad)
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp01(vidaActual); // evita que baje de 0
        ActualizarBarra();
        Debug.Log("💔 Vida reducida. Vida actual: " + vidaActual);
    }

    // 🔹 Actualiza el relleno de la barra visual
    void ActualizarBarra()
    {
        if (relleno != null)
        {
            relleno.fillAmount = vidaActual;
        }
        else
        {
            Debug.LogWarning("⚠️ No se ha asignado el objeto 'Relleno' en la barra de vida.");
        }
    }
}