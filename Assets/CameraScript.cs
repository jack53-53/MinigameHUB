using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public bool Esquerda = false;
    public bool Direita = false;
    private float speed;
    private GameObject P;
    private PlayerScript PS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        P = GameObject.FindGameObjectWithTag("Player");
        PS = P.GetComponent<PlayerScript>();
        speed = PS.Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Direita)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Esquerda)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
