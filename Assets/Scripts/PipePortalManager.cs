using UnityEngine;

public class PipePortalManager : MonoBehaviour
{
    //[SerializeField] private GameObject portalPrefab;
    //[SerializeField] private GameObject coinPrefab;

    //private GameObject goodPortal;
    //private GameObject badPortal;

    //public void SetUpPortals(float yOffset)
    //{
    //    // posiciones aleatorias para cada uno de losm portales
    //    float randomY1 = Random.Range(-yOffset, yOffset);
    //    float randomY2 = Random.Range(-yOffset, yOffset);

    //    // creamos los dos portales en posiciones diferentes
    //    goodPortal = Instantiate(portalPrefab, new Vector3(transform.position.x, randomY1, 0), Quaternion.identity, transform);
    //    badPortal = Instantiate(portalPrefab, new Vector3(transform.position.x, randomY2, 0), Quaternion.identity, transform);

    //    // le anadimos moneda al portal bueno
    //    GameObject coin = Instantiate(coinPrefab, goodPortal.transform.position, Quaternion.identity, goodPortal.transform);

    //    //Anadir muerte de player cuando pasa por portal malo, collider q haga de trigger para evento OnPlayerDeath?
    //}
}