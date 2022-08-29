using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreScipt : MonoBehaviour
{
    // Start is called before the first frame update

    public static int _scoreValue;
   [SerializeField] Text _Score;
    
    
    void Start()
    {
        _Score = GetComponent<Text>();
        _scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _Score.text= ("Score:" + _scoreValue);

    }
}
