using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialKazan : MonoBehaviour
{
    int hardnessSum;
    int elasticSum;
    int MagicSum;
    int Red =0;
    int Blue =200;
    int Green=0;
    int Trans=100;
    int ballcount =1;
    public Material kazanrenk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        kazanrenk.color = new Color32 ((byte)(Red/ballcount), (byte)(Green/ballcount),(byte)(Blue/ballcount),(byte)(Trans/ballcount));
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Material"))
        {
            hardnessSum += collision.GetComponent<Toplar>().hardness;
            elasticSum += collision.GetComponent<Toplar>().elastic;
            MagicSum += collision.GetComponent<Toplar>().magic;
            Red += collision.GetComponent<Toplar>().R;
            Blue += collision.GetComponent<Toplar>().B;
            Green += collision.GetComponent<Toplar>().G;
            Trans += collision.GetComponent<Toplar>().transperency;
            ballcount++;
            //other.gameObject.SetActive(false);
            Debug.Log("test1");
            Destroy(collision.gameObject);
        }
    }

}
