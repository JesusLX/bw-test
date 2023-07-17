# bw-test
## Test-1 AreAnagrams
Ubicado en la carpeta Pruebas > Test1-AreAnagrams
## Test-2 RunDocumentación Prueba Brainwash
Ubicado en la carpeta Pruebas > Test2-Run
## Test-3 
### Documentación

Character

Los personajes tanto del Player o los NPC comienzan con la interfaz ICharacter, ésta les permite compatibilidades a la hora de utilizar armas, PowerUps y ser afectados por los propios proyectiles.

Sistemas de pools

En el juego hay tres tipos de pools basadas en un mismo sistema: Enemigos, Proyectiles y Sistemas de partículas.
En este sistema creas un Scriptable Object que tiene: un identificador string por el cual podrás invocarlo, la capacidad máxima de ese elemento que podrás crear y el prefab del objeto IPoolItem que será el instanciado en la pool.
Cada Scriptable Object que se añade al sistema permite componer una pool individual dentro de su manager, por ejemplo: si quiero instanciar las partículas de una explosión de rayos delante de la cámara, lo único que tengo que hacer es PSManager.Play(“thunder_boom”,cam.position), y lo mismo al spawnear un enemigo en la cabeza de un alfiler.

Sistema de tiempo

El tiempo del programa se separa en Juego o no Juego. En el tiempo de Juego los enemigos pueden spawnear, moverse y atacar; lo mismo para el personaje jugador que tiene control de la cámara, lee los inputs y puede disparar.
Para poder gestionar esto tenemos el TimeManager y la interfaz ITimeAffected. Cada script que tenga que sentirse afectado por el paso y la pausa del tiempo deberá implementar esta interfaz, que le presentará las funciones necesarias para escuchar los eventos de StartPlayTime, StopPlayTime y RestorePlayTime y ya ellos decidirán qué hacer con esta información. 
Algunos de los scripts que usan esta interfaz son: WaveManager para saber cuando poder estar spawneando enemigos o los sistemas de movimientos entre otros.

Inputs

El uso de inputs para mover personajes, disparar o el control de la cámara funcionan a través de interfaces para poder ser sustituidos en cualquier momento.
El sistema de disparos del personaje coge el IMovementInput que tenga agregado, que en este caso es usar el botón izquierdo del ratón, pero el de los enemigos es automático al estar cerca del jugador dispara.

Stats y PowerUps

Los stats del personaje y los enemigos funcionan con un ScriptableObject que está dividido en cuatro enumeraciones de datos: Vida, Movimiento, Ataque y Nivel. 
Después cada elemento busca el tipo de estadística que necesita: las armas buscan el de Ataque, la salud la de Vida, los controles de movimiento la de Movimiento y el gestor de experiencia el Nivel.
Los PowerUps básicos se alimentan de este tipo de estadísticas, por lo que es fácil crear combinaciones y aplicar las mejoras a los personajes; al adquirir el PowerUp solo tiene que sumar sus estadísticas a las que este proporciona.
Las mejoras también son Scriptable Object, a la que se le añaden las estadísticas junto a una imagen representativa, un título, una descripción y un check que si está activo, la carta volverá al mazo de mejoras o se descarta.

GameManager

El GameManager se utiliza para seleccionar la fase del juego, como son el estado de Juego, selección de PowerUps, pantalla de game over o el main menu. La función del game manager es hacer las preparaciones necesarias para mostrar las diferentes vistas y llamar a los eventos necesarios para ese momento.

Singletons

En el programa hay ciertos Managers que heredan de la clase Singleton, que utiliza el patrón de diseño del mismo nombre. Por ejemplo, el GameManager o los sistemas de Pools, para poder ser accesibles y únicos desde cualquier parte del código, siendo esta una opción rápida para esta prueba.

LevelManager

Es una pequeña clase que gestiona la experiencia que obtiene el jugador y la que necesita para subir de nivel cada vez.

StatisticsManager

Sistema de estadísticas. Esta clase se suscribe a los eventos de las diferentes clases que necesita para sacar sus estadísticas.

Extras
Me he tomado la libertad de decorar un poco el mapa y el VFX con sistemas de partículas para los ataques, el spawn de los enemigos, el skybox y un arma inspirada en la que utiliza Van Helsing.


Posibles mejoras

Centralizar las funciones de MonoBehaviour en un sólo padre contenedor, para tener control sobre el orden de ejecución en las diferentes clases.
Crear PowerUps especiales, haciendo que estos no afecten únicamente a las estadísticas del jugador, sino añadir también posibles invocaciones, efectos de estado o que afecte directamente a las estadísticas del enemigo.
Realizar una mejora en cómo se hacen las inyecciones.



