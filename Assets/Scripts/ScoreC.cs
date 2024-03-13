using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreC : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public int ScoreCount = 0;
    public int Clickpower =1;
    public int upgrade = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = ScoreCount.ToString();
    }
       public void Click() {
        ScoreCount += Clickpower; 
        
    }
    public void UpgradeClick(int i)
    {
        Clickpower += i;
    }
}
