using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundOffSet : MonoBehaviour
{
    public MeshRenderer bgMeshRenderer;

    private void Start() 
    {
        bgMeshRenderer = GetComponent<MeshRenderer>();

        
        void Update()
        {
            float y = 0.01f * Time.time;
            bgMeshRenderer.material.SetTextureOffset("_MainTex",new Vector2(0, y));
        }    
    }
}
