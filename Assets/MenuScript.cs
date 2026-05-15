using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    private bool Startou;
    public GameObject DATA; //LEMBRAR DE SETAR ISSO AQ
    private Variables v;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       v = DATA.GetComponent<Variables>();
       if(v.Jogando == true)
        {
            Startou = true;
        }
    }

    public void OnJump(InputValue e)
    {
        Startou = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Startou)
        {
            //TODO: logica dos niveis // por agora os niveis vao ser hardcoded
            v.Jogando = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Random.Range(1,3));
        }
    }
}
