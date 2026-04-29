using UnityEngine;

public class CoinScript : MonoBehaviour
{
    PlayerScript PS;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PS = collision.gameObject.GetComponent<PlayerScript>();
            PS.Pontos++;
            Debug.Log(PS.Pontos.ToString());
            Object.Destroy(this);
        }
    }
}
