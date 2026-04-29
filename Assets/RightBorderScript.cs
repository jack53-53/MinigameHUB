using UnityEngine;

public class RightBorderScript : MonoBehaviour
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
            C.Direita = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            C.Direita = false;
        }
    }
}
