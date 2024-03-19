using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Button clickBtn;
    public Slider timeSlid;
    public float time;
    public float timeHolder;
    private Animator anim;
    public int health;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

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
        anim.SetTrigger("isAttack");
    }
}
