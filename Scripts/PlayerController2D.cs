using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidadCaminar = 5f;
    public float fuerzaSalto = 11f; // Un poco más alto para saltar

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool enSuelo = false;

    [Header("Detección de suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    [Header("Barra de Vida")]
    public BarraVida barraVida; // Arrastra tu objeto BarraVida aquí
    public float dañoBasura = 0.1f; // Cuánto daño hace la basura
    public float vidaBotella = 0.2f; // Cuánto aumenta la vida al tocar botella

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // --- Movimiento horizontal ---
        float movimiento = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movimiento * velocidadCaminar, rb.velocity.y);

        // --- Voltear sprite ---
        if (movimiento > 0)
            spriteRenderer.flipX = false;
        else if (movimiento < 0)
            spriteRenderer.flipX = true;

        // --- Detectar si está en el suelo ---
        enSuelo = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // --- Salto ---
        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }

        // --- Ajuste salto más natural ---
        if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2f - 1f) * Time.deltaTime;
        }
        else if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (2.5f - 1f) * Time.deltaTime;
        }
    }

    // --- Detectar colisiones con Trigger (botellas y basura) ---
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // --- Botella ---
        if (collision.CompareTag("Botella"))
        {
            Debug.Log("✅ El jugador tocó una botella");
            if (barraVida != null)
            {
                barraVida.AumentarVida(vidaBotella); // aumenta la vida
                Debug.Log("💚 Vida aumentada correctamente");
            }
            Destroy(collision.gameObject); // destruye la botella
        }

        // --- Basura ---
        if (collision.CompareTag("Basura"))
        {
            Debug.Log("💔 El jugador tocó basura");
            if (barraVida != null)
            {
                barraVida.ReducirVida(dañoBasura); // reduce la vida
                Debug.Log("💔 Vida reducida correctamente");
            }
            Destroy(collision.gameObject); // destruye la basura (opcional)
        }
    }
}