using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplar : MonoBehaviour
{
    public int hardness;
    public int elastic;
    public int magic;
    public int R;
    public int G;
    public int B;
    public int transperency;
    public Material ball;
    // Start is called before the first frame update
    void Start()
    {
        ball.color = new Color32((byte)R, (byte)G, (byte)B, (byte)transperency);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
