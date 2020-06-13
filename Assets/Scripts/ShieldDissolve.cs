using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDissolve : MonoBehaviour
{
    public Material Dissolve;
    public Material Bloom;
    private bool isDissolving = false;
    private float fade = 1.0f;

    private void Start()
    {
        Bloom = GetComponent<SpriteRenderer>().material = Bloom;
        
    }

    private void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime * 1.5f;

            if (fade <= 0.0f)
            {
                fade = 0.0f;
                Destroy(gameObject);
            }
            Dissolve = GetComponent<SpriteRenderer>().material = Dissolve;
            Dissolve.SetFloat("_Fade", fade);

            
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
             StartDestroy();
        }
    }
    
           private void StartDestroy()
    {
        isDissolving = true;
    }
}
