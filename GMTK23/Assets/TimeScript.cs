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
    bool RetrievedTimer = false;
    private void Update()
    {
       if(this.gameObject.activeInHierarchy &&!RetrievedTimer)
        {
            TimerTextVar = this.gameObject.GetComponent<TMP_Text>();
            TimerTextVar.SetText(PlayerPrefs.GetString("Timer"));
            float timerTextFloat = float.Parse(TimerTextVar.ToString());
            float timerPBTextFloat = float.Parse(timerTextPB.ToString());
            if(timerTextFloat > timerPBTextFloat)
            {
                timerTextPB.SetText(timerTextFloat.ToString());
            }
            RetrievedTimer = true;
        }
       if(!this.gameObject.activeInHierarchy && RetrievedTimer)
        {
            RetrievedTimer = false;
        }
    }

}
