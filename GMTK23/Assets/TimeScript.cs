using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    private TMP_Text TimerTextVar;
    [SerializeField]
    private TMP_Text timerTextPB;
    private int timerPB = 0;
    bool RetrievedTimer = false;
    private void Update()
    {
       if(this.gameObject.activeInHierarchy &&!RetrievedTimer)
        {
            TimerTextVar = this.gameObject.GetComponent<TMP_Text>();
            TimerTextVar.SetText(PlayerPrefs.GetString("Time"));
            int timerTextInt = PlayerPrefs.GetInt("Timer");

            if (PlayerPrefs.HasKey("PB"))
            {
                timerPB = PlayerPrefs.GetInt("PB");
                timerTextPB.SetText(PlayerPrefs.GetString("PBTime"));
            }

            if(timerTextInt < timerPB)
            {
                timerTextPB.SetText(PlayerPrefs.GetString("Time"));
                PlayerPrefs.SetString("PBTime", PlayerPrefs.GetString("Time"));
                timerPB = timerTextInt;
                PlayerPrefs.SetInt("PB", timerPB);
            }
            RetrievedTimer = true;
        }
       if(!this.gameObject.activeInHierarchy && RetrievedTimer)
        {
            RetrievedTimer = false;
        }
    }

}
