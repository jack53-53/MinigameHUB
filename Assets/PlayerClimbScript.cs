using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClimbScript : MonoBehaviour
{
    private Variables v;
    private DescedorScript[] DS;
    private Vector2 Mov;
    private int Lugar;
    public float MaxCoolDownSwitch;
    private float CoolDownSwitch;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = Variables.Instance;
        v.InMatch = true;
        v.MultPlicadorTempo = -1f;
        v.Tempo += 3;
        v.Tempo *= -1;
        v.InverterCondicao = true;
        CoolDownSwitch = MaxCoolDownSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Round(v.Tempo) % 2 == 0)
        {
            Debug.Log("PAR");
            DescerTodos();
        }
        if (Mov.x < 0f && CoolDownSwitch <= 0)
        {
            //esquerda
            if (Lugar == 1 || Lugar == 2)
            {
                Lugar -= 1;
                CoolDownSwitch = MaxCoolDownSwitch;
            }
        }
        else if(Mov.x > 0f && CoolDownSwitch <= 0)
        {
            //direita
            if (Lugar == 0 || Lugar == 1)
            {
                Lugar += 1;
                CoolDownSwitch = MaxCoolDownSwitch;
            }
        }
        if(Lugar == 0) //SWITCH CAAASSEEEE
        {
            this.transform.position = new Vector3(-2.8f, 0.87f, -6.17f);
        }
        else if(Lugar == 1)
        {
            this.transform.position = new Vector3(-0.56f, 0.87f, -6.17f);
        }
        else if(Lugar == 2)
        {
            this.transform.position = new Vector3(2.619f, 0.87f, -6.17f);
        }
        CoolDownSwitch -= Time.fixedDeltaTime;
    }


    void OnMove(InputValue e)
    {
        Mov = e.Get<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            v.Falhou();
        }
    }
    void DescerTodos() //n ta descendo, nao sei se o problema é aqui ou em outro lugar
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("TENTANDO PEGAR OBJETO");

        foreach (GameObject obj in allObjects)
        {
            Debug.Log("");
            DescedorScript descerScript = obj.GetComponent<DescedorScript>();

            if (descerScript != null)
            {
                descerScript.Descer(5);
            }
        }
    }
}
