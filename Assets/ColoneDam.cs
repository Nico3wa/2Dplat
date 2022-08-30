using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoneDam : MonoBehaviour
{
    [SerializeField] int _hp;
    [SerializeField] Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _hp = 3;
    }

    // Update is called once per frame      
    private void Update()
    {
        if (_hp == 3)
        {
            _animator.SetBool("Base", true);
        }
        if (_hp == 2)
        {
            _animator.SetBool("2hp", true);
        }
        if (_hp == 1)
        {
            _animator.SetBool("1hp", true);
        }
        if (_hp == 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(_hp);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            _hp--;
        }
    }
}
