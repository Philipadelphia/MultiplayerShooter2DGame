using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text changingText1;
    public Text changingText2;

    // Start is called before the first frame update
    void Start()
    {
        changingText1.text = "LOADING.";
        changingText2.text = "LOADING.";
    }

    // Update is called once per frame
    void Update()
    {
        changingText1.text = "LOADING..";
        changingText2.text = "LOADING..";
    }

}
