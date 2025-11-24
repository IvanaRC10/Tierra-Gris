# Tierra Gris 🌆

Juego 2D post-apocalíptico desarrollado en Unity donde el jugador debe recolectar botellas en un tiempo límite mientras evita basura tóxica.

## 🎮 Características
- Sistema de vida visual con barra
- Recolección de botellas (aumentan vida)
- Obstáculos de basura (reducen vida)
- Temporizador con condición de victoria
- Controles de plataformas 2D

## 📂 Estructura
- `Scripts/` - Contiene todos los scripts de C# del juego
  - `BarraVida.cs` - Gestiona la barra de vida del jugador
  - `BotellaScript.cs` - Lógica de las botellas recolectables
  - `PlayerController2D.cs` - Controles del personaje
  - `Temporizador.cs` - Sistema de tiempo y condiciones de victoria
  - `SeguirCamaraJugador.cs` - Sistema de cámara que sigue al jugador
  - `MonstruoHuye.cs` - Sistema de enemigos que huyen del jugador

## 🛠️ Desarrollado con
- Unity 2D
- C#