using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutlineMesh : MonoBehaviour
{
    [SerializeField]
    private Color outlineColor = Color.cyan;

    [SerializeField]
    [Range(0f,0.7f)]
    private float width = 0.7f;

    Material outlineMaterial;

    // Start is called before the first frame update
    void Awake()
    {
        Renderer renderer = GetComponent<Renderer>();
        outlineMaterial = renderer.materials.First(m => m.HasProperty("_OutlineColor") && m.HasProperty("_Outline"));

    }

    // Update is called once per frame
    //void Update()
    //{
    //    UpdateVisual(outlineMaterial);
    //}

    private void UpdateVisual(Material material)
    {
        if (material != null)
        {
            material.SetColor("_OutlineColor", outlineColor);
            material.SetFloat("_Outline", width);
        }
    }

    private void OnWillRenderObject()
    {
        UpdateVisual(outlineMaterial);
    }

    private void OnDisable()
    {
        if (outlineMaterial != null)
        {
            outlineMaterial.SetColor("_OutlineColor", Color.clear);
            outlineMaterial.SetFloat("_Outline", 0f);
            Debug.Log("Disable");
        }
    }

    private void OnValidate()
    {
        if (isActiveAndEnabled)
        {
            Renderer renderer = GetComponent<Renderer>();
            foreach (Material material in renderer.sharedMaterials)
            {
                UpdateVisual(material);
            }
        }
        
    }
}
