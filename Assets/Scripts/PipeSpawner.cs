using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private GameObject pipePortals; // Asegurate de que tenga el componente correcto!
    
    [SerializeField] private float offsetX;
    
    [SerializeField] private float spawnDelay;

    private void Awake()
    {
        GameManager.OnGameStart += OnGameStart;
        GameManager.OnGameEnd += OnGameOver;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStart -= OnGameStart;
        GameManager.OnGameEnd -= OnGameOver;
    }


    void OnGameStart() => InvokeRepeating(nameof(SpawnPipe), 0, spawnDelay);
    
    void OnGameOver() => CancelInvoke(nameof(SpawnPipe));

    void SpawnPipe()
    {
        if (pipe)
        {
            float y = Random.Range(-2.0f, 2.0f);
            Vector3 pos = new Vector3(offsetX, y, 0);
            // Instantiate(pipe, pos, Quaternion.identity);

            PipeBuilder pipeBuilder = new PipeBuilder(pipe, pos);

            if (Random.Range(0, 2) == 1)
            {
                pipeBuilder.AddOscillator(0, 0);
            }
            if (Random.Range(0, 2) == 1)
            {
                pipeBuilder.AddPortals(pipePortals);
            }

            pipeBuilder.Build();

        }
    }
}
