using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] public Transform Plane;
    [SerializeField] public GameObject SpawnablePrefab;
    [SerializeField] public Transform ParentTransform;

    [SerializeField] public float startDelay;
    [SerializeField] public float spawnInterval;
    
    private float _xValue;
    private float _zValue;
    
    void Start()
    {
        _xValue = Plane.GetComponent<MeshRenderer>().bounds.size.x / 2;
        _zValue = Plane.GetComponent<MeshRenderer>().bounds.size.z / 2; 
        
        InvokeRepeating("Spawn", startDelay, spawnInterval);

    }
    void Spawn()
    {
        GameObject spawnedObject = Instantiate(SpawnablePrefab, Vector3.zero, Quaternion.identity, ParentTransform);

        var randomXPosition = Random.Range(-_xValue, _xValue);
        var randomZPosition = Random.Range(-_zValue, _zValue);

        spawnedObject.transform.position = new Vector3(randomXPosition,0.5f, randomZPosition);
    }
}
