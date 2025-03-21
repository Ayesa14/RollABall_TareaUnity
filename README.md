# Roll-a-Ball 🕹️

Este proyecto es un juego simple en Unity llamado **Roll-a-Ball**, donde controlas una esfera que recoge objetos mientras evitas enemigos.


## **1. Crear el Proyecto en Unity**
1. Abre **Unity Hub**.
2. Crea un nuevo proyecto **3D**.
3. Nómbralo como **RollaBall** y elige una ubicación en tu PC.
4. Presiona **Create Project**.

## **2. Crear los Elementos del Juego**🎲♟️
### **Escenario y Personalización del Tablero**
1. Crea un **Plane** (GameObject → 3D Object → Plane) y ajústalo como suelo.
2. Cámbialo de nombre a `Ground` y escálalo (`Scale`) a `(10, 1, 10)`.
3. Puedes personalizarlo con **Materiales**, **Texturas** y **Luces** para hacerlo más llamativo.

### **Jugador (Bola)**⚽
1. Crea una esfera (**GameObject → 3D Object → Sphere**).
2. Cámbiale el nombre a `Player`.
3. Agrega un **Rigidbody** (para la física).
4. Crea y asigna un nuevo **Material físico** con baja fricción.
5. Crea un nuevo **Script** llamado `PlayerController` y agrégalo a la esfera.

### **Cámaras: Primera y Tercera Persona**🎥
1. Crea una nueva **Cámara** y posiciónala en `(0, 10, -10)`.
2. Crea un **Script** llamado `CameraController` para la vista en tercera persona.
3. Para la **cámara en primera persona**, crea otro script `FirstPersonCameraController`:
4. Crea otro script para poder cambiar entre cámaras pulsando una tecla

### **Estados del Jugador y Enemigos**👾💥
- **Estado Escapando**: Se activa al recoger 9 objetos y aumenta la velocidad del jugador.🏃‍♂️💨
- **Estado Inmortal**: Permite evitar daño temporalmente.🛡️
- **Enemigos Perseguidores**: Siguen al jugador si no está en modo inmortal.

### **Acelerómetro**📱🎮
- Agrega un **Acelerómetro** para controlar la velocidad del jugador con el movimiento del móvil 

### **BSO**🎶🎧
1. Crea una carpeta **Sounds** y arrastra los clips de sonido
2. Crea un nuevo **AudioSource** y asigna un sonido de fondo

---

## **¡Listo para jugar!** 🎮 

