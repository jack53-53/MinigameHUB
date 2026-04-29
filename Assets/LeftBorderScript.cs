using UnityEngine;

public class LeftBorderScript : MonoBehaviour
{
    CameraScript C;

    private void Start()
    {
        C = GetComponentInParent<CameraScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            C.Esquerda = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            C.Esquerda = false;
        }
    }
}
