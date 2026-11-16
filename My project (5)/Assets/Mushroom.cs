
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] private bool isPoisonous;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.CollectMushroom(isPoisonous);

            Destroy(gameObject);
        }
    }
}

