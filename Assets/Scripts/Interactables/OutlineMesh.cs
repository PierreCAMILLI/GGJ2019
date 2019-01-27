using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OutlineMesh : MonoBehaviour
{
    [SerializeField]
    private Color outlineColor = Color.cyan;

    [SerializeField]
    [Range(0f,3f)]
    private float width = 0.7f;

    Material[] outlineMaterials;

    // Start is called before the first frame update
    void Awake()
    {
        outlineMaterials = GetMaterials();
    }

    private Material[] GetMaterials()
    {
        List<Renderer> renderers = new List<Renderer>(GetComponentsInChildren<Renderer>());
        List<Material> materials = new List<Material>();
        foreach (Renderer renderer in renderers)
        {
            // Material[] mats = Application.isPlaying ? renderer.materials : renderer.sharedMaterials;
            Material[] mats = renderer.sharedMaterials;
            Material outline = mats.FirstOrDefault(m => m.name.Contains("Outline"));
            if (outline != null)
            {
                materials.Add(outline);
            }
        }
        return materials.ToArray();
    }

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
        foreach(Material outlineMaterial in outlineMaterials)
        {
            UpdateVisual(outlineMaterial);
        }
    }

    private void OnDisable()
    {
        if (outlineMaterials == null)
        {
            outlineMaterials = GetMaterials();
        }
        foreach (Material outlineMaterial in outlineMaterials)
        {
            outlineMaterial.SetColor("_OutlineColor", Color.clear);
            outlineMaterial.SetFloat("_Outline", 0f);
        }
    }

    private void OnValidate()
    {
        if (isActiveAndEnabled)
        {
            Material[] materials = GetMaterials();
            foreach (Material material in materials)
            {
                UpdateVisual(material);
            }
        } else
        {
            OnDisable();
        }
    }
}
