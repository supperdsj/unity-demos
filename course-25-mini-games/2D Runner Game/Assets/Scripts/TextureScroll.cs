using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    private Material backgroundMaterial;
    public float scrollSpeed = .5f;
    public bool scroll = true;

    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (scroll)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.deltaTime, 0);
            backgroundMaterial.mainTextureOffset += offset;
        }
    }
}