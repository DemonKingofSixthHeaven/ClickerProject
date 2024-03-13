using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreC : MonoBehaviour
{

    public static ScoreC instance;
    public TextMeshProUGUI Score;
    public ValueHolder holder;
    public int ScoreCount = 0;
     public int Clickpower =1;
     public int upgrade = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;    
        }
        ScoreCount = holder.score;
        Clickpower = holder.clickValue;
        upgrade = holder.DPS;
    }
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
