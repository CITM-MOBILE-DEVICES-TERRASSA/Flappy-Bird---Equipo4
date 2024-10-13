using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{

    public ParticleSystem deathParticles;







    public void DeathEf()
    {
        // Iniciar la corrutina para ralentizar el juego después de que las partículas terminen.
        StartCoroutine(HandleDeathSequence());
        // Reproducir las partículas de muerte.
        deathParticles.Play();

       
    }

    IEnumerator HandleDeathSequence()
    {
        // Esperar hasta que las partículas terminen de reproducirse.
        yield return new WaitForSeconds(deathParticles.main.duration);

        // Ralentizar el juego.
        Time.timeScale = 0.1f;

      
    }

}
