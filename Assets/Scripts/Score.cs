using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    void addscore()
    {
        VirtualCurrency.Instance.AddCurrency(10);//pasarPuntaje
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
