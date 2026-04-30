using UnityEngine;

public class CoinScript : MonoBehaviour
{
    PlayerScript PS;
    MeshRenderer MR;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("Player"))
        {
            PS = other.gameObject.GetComponent<PlayerScript>();
            PS.Pontos++;
            //Debug.Log(PS.Pontos.ToString());
            MR = this.gameObject.GetComponent<MeshRenderer>();
            MR.enabled = false;
            Destroy(this);
        }
    }
}
