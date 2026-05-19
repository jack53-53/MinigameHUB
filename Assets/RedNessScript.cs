using UnityEngine;

public class RedNessScript : MonoBehaviour
{
    public float RedNessAmount;
    private Renderer r;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = GetComponent<Renderer>();   
    }

    // Update is called once per frame
    void Update()
    {

        r.material.color = new Color(RedNessAmount, 0, 0);
    }
}
