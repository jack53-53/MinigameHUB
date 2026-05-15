using UnityEngine;

public class Variables : MonoBehaviour
{
    public bool Jogando;
    public int Vidas;
    public int Pontos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
