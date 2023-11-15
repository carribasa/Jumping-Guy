using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance { get; private set; }
    public GameObject enemyPrefab;
    public float spawnTimer = 3f;

    //! Creamos una instancia del propio SpawnManager para usarla en cualquier clase
    private void Awake()
    {
        Instance = this;
    }

    // Iniciar generacion
    public void StartSpawn()
    {
        //! Invoca la repeticion del ("asset", cuando empieza, cada cuanto)
        InvokeRepeating("SpawnEnemy", 0f, spawnTimer);
    }

    // Generar el enemigo
    void SpawnEnemy()
    {
        //! Instancia el (frefab, donde lo inserta, ???)
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    // Parar la generacion
    public void StopSpawn()
    {
        //! Cancela la invocacion del ("asset")
        CancelInvoke("SpawnEnemy");
    }
}
