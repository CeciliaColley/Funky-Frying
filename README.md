El proyecto debe ser primero y principal, un videojuego. Esto significa que no pueden haber game-breaking bugs (Un error o defecto que impide que se pueda jugarcorrectamente o que altera significativamente la experiencia de juego prevista). Cualquier caso de bug que arruine/inhabilite una mecánica, el flujo a través de las pantallas o la compleción/re-jugabilidad del juego, dejará esta entrega desaprobada automaticamente. 

Resolucion: Mi videojuego ha sido desarrollado con especial atención para evitar game-breaking bugs. He realizado pruebas exhaustivas y implementado medidas preventivas, como null checks donde sean necesarios, y limpieza de código. Para ver como mi juego fluje, puede jugarlo, o referirte al video.

El proyecto debe cumplir con la consigna del primer trabajo práctico. De no cumplir con el mismo, esta entrega queda automaticamente desaprobada.

Resolucion: mi proyecto es una continuacion de la primera entrega con varias mecánicas adicionales, como el nivel del pantry, el sistema de economia que toma en cuenta el XP del personaje, y el clipboard que sirve para que el jugador lleve ua cuenta de sus tareas pendientes. Ademas de esto, hay un cliente nuevo, el influencer, con dialogo original escrito por mi. 

No pueden haber excepciones no controladas en el proyecto o en la build. De encontrarselas mismas, queda a completo criterio del profesor la posibilidad de aprobar o desaprobar la entrega. Cualquier caso en el que el profesor decida minimizar el impacto de una excepción no controlada, al punto de dejarla pasar y aprobar la entrega, se toma como una decisión objetiva no transferible ni traducible a otros proyectos, entregas o estudiantes.

Resolucion: no he encontrado excepciones no controladas en mi proyecto.

La entrega se hace mediante un link a la release de Github.1 punto extra si se entrega a través de una página personalizada de itch.io (que tenga unbotón de descarga para acceder a la build y un link al repositorio (la página debe tenerimagenes promocionales, ya sean screenshots o arte custom, descripción, background, etc. No puede ser una página básica). 

Resolucion: entrega por github: https://github.com/CeciliaColley/Funky-Frying/releases/tag/v1.2.0

Se debe contemplar el input por controller en todas las pantallas, menues y gameplay. Todo el flujo del juego debe poder completarse sin utilizar el mouse+teclado. Se debe contemplar el input por mouse+teclado, permitiendo la completa navegación por los menues con teclado, además de poder clickear con el mouse.

Resolucion: El juego puede jugarse de inicio a fin con un controler, y tambien con el teclado. Para probar esto puedes jugar mi juego o ver los videos. Los scripts que controlan estos inputs empiezan con el prefijo Actions_. Estos fueron testeados con un XBoxOne Controller.  Para señalizar que boton utilizar, algunos objetos parpadean del color del boton al que corresponde su input. 
Los inputs son: 
Movimiento del jugador: WASD o D-pad.
Interactuar con NPC: Y o click
Utilizar puertas: X o click
Abrir Clipboard: B o click
Interactuar con UI: toggle para elegir la opcion, luego A, o click.
Cortar vegetales: D-pad o flechas del teclado.
Atrapar vegetales y ratas en el pantry: Left/Right toggle o flechas del teclado
Ir al menu: start o click

Se debe desarrollar un videojuego en el motor Unity 3D. Sus mecanicas deben ser contempladas en 2 dimensiones (a menos que el profesor apruebe su implementacion y reemplace su dificultad con otros puntos). Dicho videojuego demostrará un avance significativo en relación al primer trabajo práctico y funcionará como recuperatorio de la primer entrega (aclarado másadelante).

Resolucion: la mayor parte de arte lo hice en maya, con ayuda de un amigo, luego saqué renders, los cuales retoqué en photoshop. Nada en mi juego es comprado o conseguido en internet, excepto por las imagenes de pasta y ensalada. Todos los vegetales fueron hechos por mi, pintados a mano. Todo es en 2D.

Está prohibido entregar un juego endless (sin posibilidad de victoria). El movimiento y combate debe tener sentido. Si es un juego casual o rápido, debe sentirse fluido. Si es un juego lento, debe sentirse pesado y tener un feedback de fuerza bruta en las acciones.

Resolucion: En esta nueva version, actualize totalmente como se escuchaban los inputs. El código esta escrito de forma mucho mas prolija. Realmente quedó muy poco de como estaba antes. Me gusta como se siente cortar los vegetales, y tambien el movimiento de la canasta y el RatTrap.

Además de los menues pedidos en la consigna anterior, se debe agregar una pantalla dederrota y otra de victoria. Estas no pueden ser pantallas simples con un texto, sino que deben tener alguna coherencia visual con el resto del juego. Desde tanto la pantalla de derrota como la de victoria, se debe poder volver al menuprincipal o volver a jugar (deben estar las 2 opciones). Si el jugador pierde en la batalla con el Boss/Desafio final, debe presentarsele un botón de nuevo intento que le deje volver a jugar dicho ultimo nivel, sin necesidad de repetir el flujo completo del juego. 

Resolucion: Todas las pantallas fueron confeccionadas por mi. Para la pantalla de cocinar, tienes diferentes finales, dependiendo de tu puntaje. La pantalla de derrota en este caso no te deja servir la comida al cliente, y el juego no te da experiencia por haber cocinado. En las pantallas de victoria si te regalan experiencia, y te dan la opcion de servir la comida o intentar sacar un mejor puntuaje. Para la pantalla del pantry, siempre que termines de limpiar el pantry te va a devolver a la cocina. De aqui puedes volver al FOH, y acceder al nivel nuevamente a travéz del clipboard. Siempre y cuando no estes jugando un nivel activamente, puedes volver al menu haciendo click en el boton del menu con el mouse, o presionando start en el controller.

El juego constará de 3 tipos de niveles diferenciados (se especifican sus cantidades mínimas). Estos comprenden:

• Tutorial Cantidad: 1→Espacio libre de peligro en el que el jugador no puede perder y aprende lasmecánicas del juego.De haber enemigos en este nivel, no pueden hacer perder al jugador.
• Nivel común Cantidad: 2→Debe contemplarse 2 tipos de enemigos claramente diferenciados por lainteracción con el jugador.Estos enemigos seran presentados uno por cada nivel.1 punto extra si se agrega otro nivel con su propio enemigo claramentediferenciado.
• Desafio o boss Cantidad: 1→Se ponen a prueba las habilidades del jugador, debe contemplarse lasmecánicas de los 3 enemigos de los niveles comunes. Este desafio puede ser un Boss que haga los ataques de los enemigos comunesen ciclo (uno tras otro, con un tiempo de enfriamiento o “cooldown” de pormedio).Otra opción es una serie de ordas secuenciadas y no aleatorias que pongan aprueba al jugador. El orden, dificultad y tiempo entre las ordas debe tener un sentido y exigir del jugador la implementación de estrategias. No puede hacerse un sistema básico que no presente un real desafio.

Resolucion: 
Nivel tutorial: hay 1 llamado learn.
Nivel común: hay 3, llamados FrontOfHouse, Kitchen, y Pasta.
Boss: hay 2, llamados Kale y Pantry.

Deben agregarse los siguientes cheats, con sus inputs correspondientes (Solo se pide el input por teclado. Los cheats de tipo toggle deben cambiar su estado entre encendido y apagado al presionarsu input. Los cheats de tipo press simplemente corren su lógica una vez, cada vez que se presiona elinput.

• Inmortalidad (toggle) F10→El personaje principal no puede morir. El jugador no puede perder.
• Multiplicador de velocidad (toggle) F11→El personaje se mueve considerablemente más rapido (a criterio delestudiante, pero debe ser un multiplicador entre x2 y x5)
• Daño a todos los enemigos (press F12→Todos los enemigos en el nivel deben recibir cierta cantidad de daño(dependerá del juego, pero debe ser la mitad de la vida del enemigo más debilen el nivel).

Resolucion: Adpaté esta consigna a mi juego, ya que al ser cheats, la idea es que el juego sea mas facil.
F10: Te hace ganar automaticamente. 
F11: al cocinar hace que los ingredientes vayan mas lento, y en el pantry hace que los ingredientes y las ratas vayan mas lento.
F12: NO te hace ganar automaticamente, pero va cortando vegetales, atrapando vegetales, y atrapando ratas automaticamente sin necesidad de tu input, aunque puedes seguir jugando mientras lo tienes encendido.

Comentarios:
Los iconos en la segunda receta no escalan bien y se ven gigantes en monitores 2K (dejo imagen)

Resolucion: He seteado a todos los canvas a “scale to screen”, con X en 1920 y Y en 1080. Tengo una falta de pantallas para testear esto, pero si probé con cambiar la resolucion y pantalla de la camara de unity y parecia estar bien.

No hay input con controller.

Resolucion: añadí input con controller, usando una XBOX ONE controler para probarlo

El proyecto no está organizado.

Resolucion: Todo el proyecto esta organizado en carpetas llamadas asset, scripts, customInputs, Sprites, Music, Animation, etc. Ademas, implemente un sistema de nomenclatura en donde scripts con inputs llevan el prefijo Actions_, scripts que spawnean objetos terminan en Spawner, y scripts que definien el comportamiento de un game object terminan en Behaviour. Todo sigue convenciones de Pascal case. 

El segundo nivel es lo unico agregado en relación al primer TP y no muestra ningun cambio que haya requerido desarrollo ni agrega otro desafío, interacción o mecánica nueva.

Resolucion: Agregue la mecanica del clipboard, experiencia, dinero y el nivel del pantry. Como desafio adicional, rehice casi la totalidad del juego, en varias ocaciones borrando el script y empezando de 0. Hice lo mejor que pudo para presentar un codigo mas coherente y elocuente. 

No se resolvieron los TO-DO del parcial de forma consistente (recordar que los mismos afectan a todo el código y no solo a la linea donde fueron puestos).

Resolucion: Me aseguré de realizar los ToDos en todos los scripts. En cuanto a homogeneizar el acceso (private o public) de las variables: todas son privadas a menos que necesitan ser publicas. 
