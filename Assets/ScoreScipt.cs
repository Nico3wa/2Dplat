using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScipt : MonoBehaviour
{
    // Start is called before the first frame update

    public static int _scoreValue = 0;
    Text _Score;
    
    
    void Start()
    {
        _Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _Score.text = "Score:" + _scoreValue;
    }
}
