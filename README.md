# G2_UAGRM_Iterator

Objetivo
Utilizar el patrón Iterator como solución para integrar el uso de distintas estructuras de datos.

Descripción
La empresa Alenasoft obtuvo un contrato con Google para publicar cierta información de todos sus usuarios con fines sociales. La estructura del usuario Google es la siguiente:

  class GoogleUser {
    private String name;
    private String email;
  }

Para el acceso a la información Google provee el método:
  public GoogleUser[] getGoogleUsers();

Que devuelve a todos los usuarios google.

Con esta información se debe:
  Mostrar a todos los clientes de Google
