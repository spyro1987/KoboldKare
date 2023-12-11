#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class SharinganGUI : ShaderGUI
{
    private Font VrchatFont = (Font)Resources.Load(@"BankGothic");
    private Texture2D bannerTex = Resources.Load<Texture2D>("bg");

    private MaterialProperty _Color;
    private MaterialProperty _gColor;
    private MaterialProperty _scale;
    private MaterialProperty _scount;
    private MaterialProperty _transition;
    private MaterialProperty _rspeed;
    private MaterialProperty _roffs;

    private void DrawBanner(string text1, string text2, string URL)
    {
        GUIStyle rateTxt = new GUIStyle { font = VrchatFont };
        rateTxt.alignment = TextAnchor.LowerRight;
        rateTxt.normal.textColor = new Color(0.9f, 0.9f, 0.9f);
        rateTxt.fontSize = 12;
        rateTxt.padding = new RectOffset(0, 1, 0, 1);

        GUIStyle title = new GUIStyle(rateTxt);
        title.normal.textColor = new Color(1f, 1f, 1f);
        title.alignment = TextAnchor.MiddleCenter;
        title.fontSize = 18;

        EditorGUILayout.BeginVertical("GroupBox");
        var rect = GUILayoutUtility.GetRect(0, int.MaxValue, 35, 35);
        EditorGUI.DrawPreviewTexture(rect, bannerTex, null, ScaleMode.ScaleAndCrop);

        EditorGUI.LabelField(rect, text2, rateTxt);
        EditorGUI.LabelField(rect, text1, title);

        if (GUI.Button(rect, "", new GUIStyle()))
        {
            Application.OpenURL(URL);
        }

        EditorGUILayout.EndVertical();
    }

    public override void OnGUI(MaterialEditor editor, MaterialProperty[] properties)
    {
        Material material = editor.target as Material;

        DrawBanner("Sharingan Eye Shader", "Open Discord", "https://discord.gg/E3HPmNR");

        FindProperties(properties);

        EditorGUILayout.BeginVertical("GroupBox");

        Header("Main Settings");

        _Color.colorValue = ColorFieldHDR("Main Color", _Color.colorValue);
        _gColor.colorValue = ColorFieldHDR("Glow Color", _gColor.colorValue, true);
        editor.ShaderProperty(_scale, MakeLabel(_scale));

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("GroupBox");

        Header("Other Settings");

        editor.ShaderProperty(_transition, MakeLabel(_transition));
        editor.ShaderProperty(_scount, MakeLabel(_scount));
        editor.ShaderProperty(_rspeed, MakeLabel(_rspeed));
        editor.ShaderProperty(_roffs, MakeLabel(_roffs));

        EditorGUILayout.EndVertical();

        DrawCredits();
    }

    private static GUIContent MakeLabel(MaterialProperty property, string tooltip = null)
    {
        GUIContent staticLabel = new GUIContent();
        staticLabel.text = property.displayName;
        staticLabel.tooltip = tooltip;
        return staticLabel;
    }

    private void FindProperties(MaterialProperty[] properties)
    {
        _Color = FindProperty("_Color", properties);
        _gColor = FindProperty("_gColor", properties);
        _scale = FindProperty("_scale", properties);
        _scount = FindProperty("_scount", properties);
        _transition = FindProperty("_transition", properties);
        _rspeed = FindProperty("_rspeed", properties);
        _roffs = FindProperty("_roffs", properties);
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

    private static Color ColorFieldHDR(string name, Color ColorValue, bool alpha = false)
    {
        var result = EditorGUILayout.ColorField(new GUIContent(name), ColorValue, false, alpha, true, new ColorPickerHDRConfig(0f, 65536f, 0f, 65536f));
        return result;
    }
}
#endif