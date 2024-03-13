using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   public Button clickBtn;
   public Slider timeSlid;
   public float time;
   public float timeHolder;

   void Update()
   {
        time -= Time.deltaTime;
        timeSlid.value = time;

        if(time >= 0f)
        {
            clickBtn.interactable = false;
        }
        else
        {
            clickBtn.interactable = true;
        }
   } 

   public void ClickBtn()
   {
        time = timeHolder;
   }
}
