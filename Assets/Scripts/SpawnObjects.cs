using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private Transform plane;
    [SerializeField] private GameObject spawnablePrefab;
    [SerializeField] private Transform parentTransform;

    [SerializeField] private float startDelay;
    [SerializeField] private float spawnInterval;
    
    private float xValue;
    private float zValue;
    
    void Start()
    {
        FindBoundsOfPlane();

        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }

    private void FindBoundsOfPlane()
    {
        xValue = plane.GetComponent<MeshRenderer>().bounds.size.x / 2 - 10 ;
        zValue = plane.GetComponent<MeshRenderer>().bounds.size.z / 2 - 10;
    }

    void Spawn()
    {
        GameObject spawnedObject = Instantiate(spawnablePrefab, Vector3.zero, Quaternion.identity, parentTransform);

        var randomXPosition = Random.Range(-xValue, xValue);
        var randomZPosition = Random.Range(-zValue, zValue);

        spawnedObject.transform.position = new Vector3(randomXPosition,0.5f, randomZPosition);
    }
}
