# Cambios de la rama `update-2026`

> Esta rama es el mismo curso —el curso de Unity 2019—, preparada para abrirse con **Unity 6**. La rama
> principal sigue exactamente como en el vídeo.
> Revisado contra el código fuente de Unity 6 y **comprobado abriendo los proyectos en el editor de Unity 6** (octubre de 2026). Si algo no abre o no compila, cuéntalo en la comunidad del curso.

## Cómo usarla

1. Instala **Unity 6** (la versión LTS que te ofrezca Unity Hub).
2. Descarga solo esta rama: `git clone --depth 1 -b update-2026 https://github.com/joanby/cursos-unity-2019` (o, en GitHub, cambia a la
   rama `update-2026` y *Code → Download ZIP*). Sin el `--depth 1`, git se trae también el historial
   de la rama principal, con la caché antigua dentro.
3. En Unity Hub, **Add → Add project from disk** y elige la carpeta de un proyecto (`Legend of Selda`, `MyFirstProject`),
   no la raíz del repositorio.
4. Unity te avisará de que el proyecto es de una versión anterior: acepta la actualización.

## Qué ha cambiado y por qué

### La caché de Unity ya no está en el repositorio

La rama principal guarda en git la caché de Unity (`Library/`, `Logs/`, `obj/`…): **10044 de los 13951 ficheros**. Unity la regenera al abrir el proyecto y con Unity 6 se reconstruye
entera, así que solo hacía la descarga enorme. En esta rama no está, y el `.gitignore` evita que vuelva.
**No cambia nada de lo que ves en el vídeo:** escenas, scripts, modelos, materiales y ajustes siguen ahí.

### Paquetes que el curso no usaba

Venían con la plantilla del proyecto y ningún script, escena ni asset los usa (comprobado
componente a componente). En Unity 6 son servicios o herramientas que han cambiado o se han retirado.

- `Legend of Selda`: Unity Ads, Analytics, In-App Purchasing, Collab, Package Manager UI (antiguo)
- `MyFirstProject`: Unity Ads, Analytics, In-App Purchasing, Collab, Package Manager UI (antiguo)

### El código del curso no se ha tocado

Los scripts que escribimos en el vídeo están igual. Lo que puedes ver en la consola de Unity 6:

- `Legend of Selda`: .velocity (en Rigidbody, hoy linearVelocity; lo cambia el API Updater); FindObjectOfType (obsoleto: aviso amarillo)
- `MyFirstProject`: .velocity (en Rigidbody, hoy linearVelocity; lo cambia el API Updater)

Son avisos (amarillos) o cambios que Unity hace solo al abrir el proyecto: el juego funciona igual.

## Lo que se ve distinto al vídeo

La interfaz del editor: Unity 6 ha movido y rediseñado paneles y menús. Lo que aprendes en el
curso (componentes, físicas, scripts, escenas) es exactamente lo mismo.
