using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public ValueHolder scores;
    
    public void MaiMenu() 
    {
        scores.clickValue = ScoreC.instance.Clickpower;
        scores.score = ScoreC.instance.ScoreCount;
        SceneManager.LoadScene(0);

    }
    public void GameStart()
    {

        SceneManager.LoadScene(1);
        //ScoreC.instance.Clickpower=scores.clickValue ;
        //ScoreC.instance.ScoreCount= scores.score;

    }
}
