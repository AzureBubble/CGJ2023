using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform[] childs;

    // Start is called before the first frame update
    private void Start()
    {
        childs = new Transform[GameObject.Find("Back").transform.childCount];
        //childs = new Transform[transform.childCount];
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i] = GameObject.Find("Back").transform.GetChild(i);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].rotation = Camera.main.transform.rotation;
        }
    }
}