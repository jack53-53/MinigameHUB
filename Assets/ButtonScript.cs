using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class ButtonScript : MonoBehaviour
{
    private Variables v;
    private Renderer r;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = GetComponent<Renderer>();
        v = Variables.Instance;
        v.InMatch = true;
    }

    void OnJump(InputValue e)
    {
        if(e.isPressed)
        {
            v.Tempo = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(v.Tempo <= 1f)
        {
            v.Passou = true;
        }
        if(v.Tempo <= 3f)
        {
            r.material.color = Color.green;
        }
        if(v.Tempo <= 4f)
        {
            r.material.color = Color.yellow;
        }
    }
}
