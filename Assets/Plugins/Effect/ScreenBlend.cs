using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBlend : PostEffectsBase {

    //public Shader briSatConShader;
    //private Material briSatConMaterial;
    //public Material material
    //{
    //    get
    //    {
    //        briSatConMaterial = CheckShaderAndCreateMaterial(briSatConShader, briSatConMaterial);
    //        return briSatConMaterial;
    //    }
    //}

    //[Range(0.0f, 3.0f)]
    //public float brightness = 1.0f;

    //[Range(0.0f, 3.0f)]
    //public float saturation = 1.0f;

    //[Range(0.0f, 3.0f)]
    //public float contrast = 1.0f;

    //void OnRenderImage(RenderTexture src, RenderTexture dest)
    //{
    //    if (material != null)
    //    {
    //        material.SetFloat("_Brightness", brightness);
    //        material.SetFloat("_Saturation", saturation);
    //        material.SetFloat("_Contrast", contrast);

    //        Graphics.Blit(src, dest, material);
    //    }
    //    else
    //    {
    //        Graphics.Blit(src, dest);
    //    }
    //}

    public Shader m_shader;
    private Material m_material;

    [Range(0.0f, 3.0f)]
    public float m_opacity;
    public Texture2D m_blendTexture;


    public Material material
    {
        get
        {
            m_material = CheckShaderAndCreateMaterial(m_shader, m_material);

            return m_material;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material != null)
        {
            material.SetFloat("_Opacity", m_opacity);
            material.SetTexture("_BlendTex", m_blendTexture);

            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
