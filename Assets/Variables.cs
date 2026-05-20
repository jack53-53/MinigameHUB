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
    public bool InverterCondicao;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        InverterCondicao = false;
    }

    private void FixedUpdate()
    {
        if (InMatch){
            Tempo -= Time.fixedDeltaTime * MultPlicadorTempo;
            if(!InverterCondicao)
            {
                    if (Passou)
                    {
                        Pontos++;
                    Passou = false;
                        InMatch = false;
                        SceneManager.LoadScene("Main");
                    }
                    else if (Tempo <= 0)
                    {
                        Vidas--;
                    Passou = false;
                    InMatch = false;
                        SceneManager.LoadScene("Main");
                    }
            }
            else //se o jogo for de sobrevivencia, e depender do tempo acabar para o jogador ganhar
            {
                if (Tempo >= 0)
                {
                    InMatch = false;
                    InverterCondicao = false;
                    Pontos++;
                    SceneManager.LoadScene("Main");
                }
                else
                {
                    Passou = false;
                }
            }
        }
    }
    public void Falhou()
    {
        Vidas--;
        SceneManager.LoadScene("Main");
    }
    public void Ganhou()
    {
        InMatch = false;
        Pontos++;
        SceneManager.LoadScene("Main");
    }
}
