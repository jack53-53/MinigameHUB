using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    private bool Startou;
    private Variables v;
    public TextMeshProUGUI txt;
    private float WaitTime = 3f;
    public TextMeshProUGUI txt2;
    public float CoolDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        v = Variables.Instance;
        v.Jogando = false;
        Startou = false;
        txt.text = "Vidas: " + v.Vidas.ToString();
        txt2.text = "Pontos: " + v.Pontos.ToString();
        v.InMatch = false;
        v.MTempo -= v.MTempo * 0.10f; //tirar 10% do tempo a cada vez que ele vai pro lobby
        v.Tempo = v.MTempo;
    }

    public void OnJump(InputValue e)
    {
        if (v.Jogando == false && CoolDown <= 0)
        {
            Startou = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Startou || WaitTime == 0)
        {
            // por agora os niveis vao ser hardcoded
            v.Jogando = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + Random.Range(1,6));//aparentemente tem um jeito de fazer com que ele pegue o numero de cenas no editor automaticamente, eu nao entendi esse metodo.
        }
        CoolDown -= Time.fixedDeltaTime;
    }
}
