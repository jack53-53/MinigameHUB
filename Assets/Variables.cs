using UnityEngine;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{

    public static Variables Instance { get; private set; }

    public bool Jogando;
    public int Vidas = 3;
    public int Pontos;
    public float MTempo = 11f;
    public float Tempo = 11f; //começa com 10 segundos e vai acelerando x% cada rodada?
    public float MultPlicadorTempo = 1f; //alguns niveis podem talvez ser mais longos ou curtos
    public int NumRondas;
    public bool Passou;
    public bool InMatch; //setar dentro do prefab do player dentro do nivel
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        if (InMatch){
            //Debug.Log(Tempo);
            Tempo -= Time.fixedDeltaTime * MultPlicadorTempo;
            if(Tempo <= 0)
            {
                Vidas--;
                InMatch = false;
                SceneManager.LoadScene("Main");
            }
            else if(Passou == true)
            {
                InMatch = false;
                SceneManager.LoadScene("Main");
                Pontos++;
            }
        }
        else
        {
            Passou = false;
        }
    }
}
