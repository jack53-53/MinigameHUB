using UnityEngine;

public class DescedorScript : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("Lixo location: " + gameObject.transform.position.y);
    }
    public void Descer(int QuantDescer)
    {
        this.gameObject.transform.position = new Vector3(this.transform.position.x - QuantDescer, this.transform.position.y, this.transform.position.z);
    }
}
