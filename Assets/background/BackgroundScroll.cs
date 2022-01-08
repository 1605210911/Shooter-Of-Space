using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float speed = 0.1f;
    public Renderer meshRendrer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector2 offset = meshRendrer.material.mainTextureOffset;
       offset = offset+new Vector2(0,speed*Time.deltaTime);
       meshRendrer.material.mainTextureOffset = offset;
    }
}
