using UnityEngine;

public class EnemyHeadColliderScript : MonoBehaviour
{
    public bool TOCOU = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FeetTag"))
        {
            TOCOU = true;
        }
    }
}
