using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBackground : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public GameObject background;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsRun", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
