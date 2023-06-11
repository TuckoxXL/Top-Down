using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemy : MonoBehaviour
{
    public GameObject objetoAspawnear;

    public float minX;
    public float maxX;
    public float Ypos;
    public float mintiempoSpawn = 0f;
    public float maxtiempoSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnObstaculo(Random.Range(mintiempoSpawn, maxtiempoSpawn), objetoAspawnear));

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator spawnObstaculo(float intervalo, GameObject obstaculo)
    {
        yield return new WaitForSeconds(intervalo);
        Instantiate(obstaculo, new Vector3(Random.Range(minX, maxX), Ypos, 0), Quaternion.identity);
        StartCoroutine(spawnObstaculo(intervalo, obstaculo));
    }
}
