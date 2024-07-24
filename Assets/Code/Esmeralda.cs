using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esmeralda : MonoBehaviour
{
    public GameObject esmeralda;
    public BoxCollider2D spawnArea;

    private void Start()
    {
        SpawnMagicSphere();
    }

    private void SpawnMagicSphere()
    {
        Bounds bounds = spawnArea.bounds;

        Vector3 randomPosition = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0
        );
        Instantiate(esmeralda, randomPosition, Quaternion.identity);
    }
}
