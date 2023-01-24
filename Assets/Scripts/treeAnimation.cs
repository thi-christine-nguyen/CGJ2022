using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeAnimation : MonoBehaviour
{
    private bool isGrowing = true;
    private bool isAlreadyCollided = false;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrowing)
        {
            anim.SetBool("isGrowing", true);
        }
        else
        {
            anim.SetBool("isGrowing", false);
        }
    }
}
