using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlat : MonoBehaviour
{
    public float _speed; // vitesse de la plateform
    public int startingPoint; // point de démarage
    public Transform[] points; // le point de fin

    private int i;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position; 
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
        if(i >= points.Length)
            {
                i = 0; // reset index
            }
        
        }  
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, _speed* Time.deltaTime) ;
    }
      private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
  private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
