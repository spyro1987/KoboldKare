#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

public class JayGamerPackOPunchGUI : ShaderGUI
{
    private BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

    private MaterialProperty _TextureSample2 = null;
    private MaterialProperty _DistortionTexture2 = null;
    private MaterialProperty _Vector4 = null;
    private MaterialProperty _TextureSample8 = null;
    private MaterialProperty _Float4 = null;
    private MaterialProperty _Vector12 = null;
    private MaterialProperty _TexDistortionUV1 = null;
    private MaterialProperty _TexDistortionUV2 = null;
    private MaterialProperty _TextureSample0 = null;
    private MaterialProperty _black = null;
    private MaterialProperty _TextureSample4 = null;
    private MaterialProperty _TextureSample5 = null;
    private MaterialProperty _TextureSample7 = null;
    private MaterialProperty _Disstortioncolor = null;
    private MaterialProperty _Distortionparallax = null;
    private MaterialProperty _DistortionParallax2 = null;
    private MaterialProperty _Distortioncolor2 = null;
    private MaterialProperty _DistortionBrightness1 = null;
    private MaterialProperty _DistortionBrightness2 = null;
    private MaterialProperty _BlackRimzoom = null;
    private MaterialProperty _BlackedgeBlackRim = null;
    private MaterialProperty _parallaxBlackRim = null;
    private MaterialProperty _GrayScaleDistortion = null;
    private MaterialProperty _Texturevignette = null;
    private MaterialProperty _DistortionParallax = null;
    private MaterialProperty _NormalmapTexture = null;
    private MaterialProperty _Texture3 = null;
    private MaterialProperty _Normalmap = null;
    private MaterialProperty _Float5 = null;
    private MaterialProperty _Rainbow = null;
    private MaterialProperty _Saturation = null;
    private MaterialProperty _rainbowmove = null;
    private MaterialProperty _NormalsScale = null;
    private MaterialProperty _TextureSample9 = null;
    private MaterialProperty _Color1 = null;
    private MaterialProperty _Texture3Move = null;
    private MaterialProperty _DistortionMove3 = null;
    private MaterialProperty _DistortionMove1 = null;
    private MaterialProperty _Texture2Move = null;

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties)
    {
        Material material = editor.target as Material;
        Shader shader = material.shader;

        foreach (var property in GetType().GetFields(bindingFlags))
        {
            if (property.FieldType == typeof(MaterialProperty))
            {
                try { property.SetValue(this, FindProperty(property.Name, properties)); } catch { }
            }
        }
        NeonDrawBanner("JayGamer Pack O Punch Shader", "JayGamer#7096");

        GUILayout.BeginVertical("GroupBox");

        MakeFoldout(material, "_MainSettings", "Main Settings");
        if (material.GetInt("_MainSettings") == 1)
        {
            editor.ShaderProperty(_TextureSample2, NeonMakeLabel(_TextureSample2));
            editor.ShaderProperty(_TextureSample5, NeonMakeLabel(_TextureSample5));
            editor.ShaderProperty(_TextureSample7, NeonMakeLabel(_TextureSample7));
            editor.ShaderProperty(_DistortionTexture2, NeonMakeLabel(_DistortionTexture2));
            editor.ShaderProperty(_Vector12, NeonMakeLabel(_Vector12));
            editor.ShaderProperty(_GrayScaleDistortion, NeonMakeLabel(_GrayScaleDistortion));
            editor.ShaderProperty(_Disstortioncolor, NeonMakeLabel(_Disstortioncolor));
            editor.ShaderProperty(_Distortioncolor2, NeonMakeLabel(_Distortioncolor2));
            editor.ShaderProperty(_TextureSample9, NeonMakeLabel(_TextureSample9));
            editor.ShaderProperty(_Color1, NeonMakeLabel(_Color1));
            editor.ShaderProperty(_DistortionBrightness1, NeonMakeLabel(_DistortionBrightness1));
            editor.ShaderProperty(_DistortionBrightness2, NeonMakeLabel(_DistortionBrightness2));
        }

        MakeFoldout(material, "_DissolveSettings", "Dissolve Settings");
        if (material.GetInt("_DissolveSettings") == 1)
        {
            editor.ShaderProperty(_TextureSample8, NeonMakeLabel(_TextureSample8));
            editor.ShaderProperty(_Float4, NeonMakeLabel(_Float4));
        }

        MakeFoldout(material, "_NormalSettings", "Normal Settings");
        if (material.GetInt("_NormalSettings") == 1)
        {
            editor.ShaderProperty(_NormalmapTexture, NeonMakeLabel(_NormalmapTexture));
            editor.ShaderProperty(_Normalmap, NeonMakeLabel(_Normalmap));
        }

        MakeFoldout(material, "_BlackRimSettings", "BlackRim Settings");
        if (material.GetInt("_BlackRimSettings") == 1)
        {
            editor.ShaderProperty(_Texturevignette, NeonMakeLabel(_Texturevignette));
            editor.ShaderProperty(_BlackRimzoom, NeonMakeLabel(_BlackRimzoom));
            editor.ShaderProperty(_BlackedgeBlackRim, NeonMakeLabel(_BlackedgeBlackRim));
            editor.ShaderProperty(_parallaxBlackRim, NeonMakeLabel(_parallaxBlackRim));
            editor.ShaderProperty(_Float5, NeonMakeLabel(_Float5));
            editor.ShaderProperty(_Vector4, NeonMakeLabel(_Vector4));
        }

        MakeFoldout(material, "_ParallaxSetting", "Parallax Settings");
        if (material.GetInt("_ParallaxSetting") == 1)
        {
            editor.ShaderProperty(_Distortionparallax, NeonMakeLabel(_Distortionparallax));
            editor.ShaderProperty(_DistortionParallax2, NeonMakeLabel(_DistortionParallax2));
        }

        MakeFoldout(material, "_DistortionSettings", "Distortion Settings");
        if (material.GetInt("_DistortionSettings") == 1)
        {
            editor.ShaderProperty(_black, NeonMakeLabel(_black));
            editor.ShaderProperty(_DistortionMove3, NeonMakeLabel(_DistortionMove3));
            editor.ShaderProperty(_TextureSample4, NeonMakeLabel(_TextureSample4));
            editor.ShaderProperty(_TextureSample0, NeonMakeLabel(_TextureSample0));
            editor.ShaderProperty(_DistortionMove1, NeonMakeLabel(_DistortionMove1));
        }

        MakeFoldout(material, "_RainbowSettings", "Rainbow Settings");
        if (material.GetInt("_RainbowSettings") == 1)
        {
            editor.ShaderProperty(_Rainbow, NeonMakeLabel(_Rainbow));
            editor.ShaderProperty(_Saturation, NeonMakeLabel(_Saturation));
            editor.ShaderProperty(_rainbowmove, NeonMakeLabel(_rainbowmove));
        }

        NeonCredits();

        GUILayout.EndVertical();
    }

    private void NeonMessage(string text)
    {
        var Style = new GUIStyle
        {
            fontSize = 12,
            fontStyle = FontStyle.Italic,
            alignment = TextAnchor.MiddleLeft
        };
        Style.normal.textColor = new Color(1f, 0f, 0f);
        GUILayout.Label(text, Style);
    }
    private static GUIContent NeonMakeLabel(MaterialProperty property, string tooltip = null)
    {
        GUIContent staticLabel = new GUIContent
        {
            text = property.displayName,
            tooltip = tooltip
        };
        return staticLabel;
    }
    private void NeonHeader(string name)
    {
        var Style = new GUIStyle
        {
            fontStyle = FontStyle.Italic,
            fontSize = 15,
            alignment = TextAnchor.MiddleLeft
        };
        GUILayout.Label(name, Style);
        GUILayout.Space(5);
    }
    private void MakeFoldout(Material material, string property, string name)
    {
        EditorGUILayout.BeginHorizontal("Button");

        GUILayout.Space(10);
        material.SetInt(property, EditorGUILayout.Foldout(material.GetInt(property) > 0, name, true) ? 1 : 0);

        EditorGUILayout.EndHorizontal();
    }
    private void NeonDrawBanner(string text, string info)
    {
        GUIStyle title = new GUIStyle
        {
            fontStyle = FontStyle.Italic,
            alignment = TextAnchor.MiddleCenter,
            fontSize = 20,
            padding = new RectOffset(0, 1, 0, 1)
        };
        title.normal.textColor = new Color(0f, 0f, 0f);
        EditorGUILayout.BeginVertical("Box");
        var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 40, 40);
        EditorGUI.DrawRect(rect, new Color(1f, 1f, 1f, 0f));
        EditorGUI.LabelField(rect, text, title);
        EditorGUILayout.EndVertical();
    }
    private void NeonCredits()
    {
        GUIStyle words = new GUIStyle
        {
            alignment = TextAnchor.UpperLeft,
            fontSize = 15,
            fontStyle = FontStyle.Italic,
        };
        words.normal.textColor = new Color(0f, 0f, 0f);
        EditorGUILayout.BeginVertical("GroupBox");
        var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 35, 35);
        EditorGUI.LabelField(rect, "Shader by:JayGamer#7096\nShaderGUI: by Neon#6653", words);
        EditorGUILayout.EndVertical();
    }
}
#endif