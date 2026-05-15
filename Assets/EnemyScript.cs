using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyScript : MonoBehaviour
{
    private PlayerScript ps;
    private InputValue V;
    private GameObject p;
    public bool Direita;
    private Rigidbody RB;
    public float Speed;
    private Collider col;
    private float Parede;
    public LayerMask WallLayer;
    private EnemyHeadColliderScript EHC;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        p = GameObject.FindGameObjectWithTag("Player");
        ps = p.GetComponent<PlayerScript>();
        col = GetComponent<Collider>();
        Parede = col.bounds.extents.x;
        EHC = GetComponentInChildren<EnemyHeadColliderScript>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Direita)
        {
            RB.linearVelocity = new Vector3(Speed, 0, 0);
        }
        else
        {
            RB.linearVelocity = new Vector3(-Speed, 0, 0);
        }

        bool wallLeft = Physics.Raycast(transform.position, Vector3.left, Parede + 0.1f, WallLayer);
        bool wallRight = Physics.Raycast(transform.position, Vector3.right, Parede + 0.5f, WallLayer);

        Debug.DrawRay(transform.position, Vector3.left * (Parede + 0.1f), Color.red);
        Debug.DrawRay(transform.position, Vector3.right * (Parede + 0.1f), Color.blue);

        if (wallLeft)
        {
            Direita = true;
        }

        if (wallRight)
        {
            Direita = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (EHC.TOCOU)
        {
            //CapsuleCollider c = this.GetComponent<CapsuleCollider>();
            //MeshRenderer m = this.gameObject.GetComponent<MeshRenderer>();
            //c.enabled = false;
            //m.enabled = false;
            ps.ForcedJump();
            Destroy(this.gameObject);

        }
    }
}
