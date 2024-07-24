using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int vida = 10;
    public int dañoAtaque = 3;
    public int dañoProyectil = 2;
    public int dañoMagia = 1;
    public float tiempoEspera = 3.0f;
    public float velocidad = 2.0f;
    public Transform player;

    private bool persiguiendo = false;
    private int secuenciaAtaque = 0;

    private void Update()
    {
        if (persiguiendo)
        {
            PerseguirJugador();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            persiguiendo = true;
            StartCoroutine(SecuenciaAtaques());
        }
    }

    private void PerseguirJugador()
    {
        if (player != null)
        {
            Vector3 direccion = (player.position - transform.position).normalized;
            transform.position += direccion * velocidad * Time.deltaTime;
        }
    }

    private IEnumerator SecuenciaAtaques()
    {
        while (vida > 0)
        {
            switch (secuenciaAtaque)
            {
                case 0:
                case 1:
                    // Ataque con proyectil
                    Proyectil();
                    break;
                case 2:
                    // Ataque cuerpo a cuerpo
                    Ataque();
                    break;
                case 3:
                    // Ataque de magia
                    Magia();
                    break;
            }

            secuenciaAtaque = (secuenciaAtaque + 1) % 4;
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    private void Proyectil()
    {
        // Lógica para lanzar proyectil y causar daño al jugador
        Debug.Log("Proyectil lanzado. Daño: " + dañoProyectil);
        // Aquí puedes instanciar el proyectil y definir su comportamiento
    }

    private void Ataque()
    {
        // Lógica para ataque cuerpo a cuerpo y causar daño al jugador
        Debug.Log("Ataque cuerpo a cuerpo. Daño: " + dañoAtaque);
        // Aquí puedes implementar el daño directo al jugador si está en rango
    }

    private void Magia()
    {
        // Lógica para ataque de magia y causar daño al jugador
        Debug.Log("Ataque de magia. Daño: " + dañoMagia);
        // Aquí puedes instanciar el ataque de magia y definir su comportamiento
    }
}
