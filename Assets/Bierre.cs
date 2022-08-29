using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bierre : MonoBehaviour
{
    // Start is called before the first frame update
   
        private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            ScoreScipt._scoreValue += 1;
            Destroy(gameObject);
        }
    }
   

    // Update is called once per frame
    void Update()
    {
    
    }
}
