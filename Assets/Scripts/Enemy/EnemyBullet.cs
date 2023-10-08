using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerHealth.OnHealthDecreased();
            Destroy(gameObject);

        }
    }
}
