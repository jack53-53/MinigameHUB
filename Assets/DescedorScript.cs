using UnityEngine;

public class DescedorScript : MonoBehaviour
{
    public void Descer(int QuantDescer)
    {
        this.gameObject.transform.position = new Vector3(this.transform.position.x - QuantDescer, this.transform.position.y, this.transform.position.z);
    }
}
