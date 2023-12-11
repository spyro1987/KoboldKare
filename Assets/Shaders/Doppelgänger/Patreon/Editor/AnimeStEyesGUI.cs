#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.Linq;
using System.Reflection;

public class AnimeStEyesGUI : ShaderGUI
{
    private Font VrchatFont = (Font)Resources.Load(@"BankGothic");

    private BindingFlags bindingFlags = BindingFlags.Public |
                                    BindingFlags.NonPublic |
                                    BindingFlags.Instance |
                                    BindingFlags.Static;

    private MaterialProperty _MainTex = null;
    private MaterialProperty _Color = null;
    private MaterialProperty _Color2 = null;
    private MaterialProperty _HighLightColor = null;
    private MaterialProperty HLA = null;
    private MaterialProperty _hlmo = null;
    private MaterialProperty _pcol = null;
    private MaterialProperty _pcol2 = null;
    private MaterialProperty _Pulsatepower = null;
    private MaterialProperty _Pulsatespeed = null;
    private MaterialProperty _Vignette = null;
    private MaterialProperty _Vignettesmtf = null;

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties)
    {
        Material material = editor.target as Material;
        Shader shader = material.shader;

        //Thanks Xiexe
        foreach (var property in GetType().GetFields(bindingFlags))
        {
            if (property.FieldType == typeof(MaterialProperty))
            {
                try { property.SetValue(this, FindProperty(property.Name, properties)); } catch { }
            }
        }
        //

        DrawBanner(shader.name.Split('/').Last(), "Open Discord", "https://discord.gg/E3HPmNR");

        EditorGUILayout.BeginVertical("GroupBox");

        Header("Main Settings");

        editor.TexturePropertySingleLine(new GUIContent(_MainTex.displayName), _MainTex);
        editor.TextureScaleOffsetProperty(_MainTex);
        editor.ShaderProperty(_Color, MakeLabel(_Color));
        editor.ShaderProperty(_Color2, MakeLabel(_Color2));
        editor.ShaderProperty(_pcol, MakeLabel(_pcol));
        editor.ShaderProperty(_pcol2, MakeLabel(_pcol2));

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("GroupBox");

        Header("HighLights Settings");

        editor.ShaderProperty(_HighLightColor, MakeLabel(_HighLightColor));
        editor.ShaderProperty(HLA, MakeLabel(HLA));
        if (material.GetInt("HLA") == 2)
        {
            editor.ShaderProperty(_hlmo, MakeLabel(_hlmo));
        }


        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("GroupBox");

        Header("Other Settings");

        editor.ShaderProperty(_Pulsatepower, MakeLabel(_Pulsatepower));
        editor.ShaderProperty(_Pulsatespeed, MakeLabel(_Pulsatespeed));
        editor.ShaderProperty(_Vignette, MakeLabel(_Vignette));
        editor.ShaderProperty(_Vignettesmtf, MakeLabel(_Vignettesmtf));

        EditorGUILayout.EndVertical();

        DrawBanner("Patreon", "Open Patreon", "https://www.patreon.com/dopestuff");

        DrawCredits();
    }

    private void DrawBanner(string text1, string text2, string URL)
    {
        GUIStyle rateTxt = new GUIStyle { font = VrchatFont, alignment = TextAnchor.LowerRight, fontSize = 12, padding = new RectOffset(0, 1, 0, 1) };
        rateTxt.normal.textColor = new Color(0.9f, 0.9f, 0.9f);

        GUIStyle title = new GUIStyle { font = VrchatFont, alignment = TextAnchor.MiddleCenter, fontSize = 18, padding = new RectOffset(0, 1, 0, 1) };
        title.normal.textColor = new Color(1f, 1f, 1f);

        EditorGUILayout.BeginVertical("GroupBox");
        var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 35, 35);
        EditorGUI.DrawRect(rect, new Color(0f, 0f, 0f));
        EditorGUI.LabelField(rect, text2, rateTxt);
        EditorGUI.LabelField(rect, text1, title);

        if (GUI.Button(rect, "", new GUIStyle()))
        {
            Application.OpenURL(URL);
        }

        EditorGUILayout.EndVertical();
    }

    private static GUIContent MakeLabel(MaterialProperty property, string tooltip = null)
    {
        GUIContent staticLabel = new GUIContent { text = property.displayName, tooltip = tooltip };
        return staticLabel;
    }

    private void DrawCredits()
    {
        EditorGUILayout.BeginVertical("GroupBox");

        var TextStyle = new GUIStyle { font = VrchatFont, fontSize = 15, fontStyle = FontStyle.Italic };
        GUILayout.Label("Shader by:", TextStyle);
        GUILayout.Space(2);
        GUILayout.Label("Doppelgänger#8376", TextStyle);
        GUILayout.Space(6);
        GUILayout.Label("Thanks for help with editor:", TextStyle);
        GUILayout.Space(2);
        GUILayout.Label("Bkp#8336", TextStyle);

        EditorGUILayout.EndVertical();
    }

    private void Header(string name)
    {
        var Style = new GUIStyle { font = VrchatFont, fontSize = 18, fontStyle = FontStyle.Italic, alignment = TextAnchor.MiddleLeft };
        GUILayout.Label(name, Style);
        GUILayout.Space(5);
    }
}
#endif