using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{

    public ParticleSystem deathParticles;







    public void DeathEf()
    {
        // Iniciar la corrutina para ralentizar el juego despu�s de que las part�culas terminen.
        StartCoroutine(HandleDeathSequence());
        // Reproducir las part�culas de muerte.
        deathParticles.Play();

       
    }

    IEnumerator HandleDeathSequence()
    {
        // Esperar hasta que las part�culas terminen de reproducirse.
        yield return new WaitForSeconds(deathParticles.main.duration);

        // Ralentizar el juego.
        //Time.timeScale = 0.1f;

      
    }

}
