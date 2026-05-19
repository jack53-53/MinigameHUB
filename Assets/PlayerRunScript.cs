using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunScript : MonoBehaviour
{
    public int metaCliques;
    private int Cliques;
    private Variables v;
    public float WalkAmmount;
    public bool MoveSe;
    private RedNessScript RN;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = Variables.Instance;
        if(v != null)
        {
            v.InMatch = true;
        }
        RN = GetComponent<RedNessScript>();
    }

    void OnJump(InputValue e)
    {
        if (e.isPressed == true)
        {
            Cliques++;
            if (MoveSe)
            {
                this.transform.position = new Vector3(this.transform.position.x + WalkAmmount, this.transform.position.y, this.transform.position.z);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (RN != null) {
            RN.RedNessAmount = Cliques * 0.1f;
        }
        if(metaCliques == Cliques)
        {
            //Debug.Log("PASSOU");
            v.Passou = true;
        }
    }
}
