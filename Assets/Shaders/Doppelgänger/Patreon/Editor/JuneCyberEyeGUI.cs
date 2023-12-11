#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class JuneCyberEyeGUI : ShaderGUI
{
    private Font VrchatFont = (Font)Resources.Load(@"BankGothic");
    private Texture2D bannerTex = Resources.Load<Texture2D>("bg");

    private MaterialProperty _MainTex;
    private MaterialProperty _Color;
    private MaterialProperty _rcolor;
    private MaterialProperty _pcolor;
    private MaterialProperty _gcolor;
    private MaterialProperty _pgcolor;
    private MaterialProperty _Pulsatepower;
    private MaterialProperty _Pulsatespeed;
    private MaterialProperty _Pulsatepower2;
    private MaterialProperty _Pulsatespeed2;
    private MaterialProperty _totalspeed;

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

        DrawBanner("June Cyber Eye", "Open Discord", "https://discord.gg/5PHerbf");

        FindProperties(properties);

        EditorGUILayout.BeginVertical("GroupBox");

        Header("Main Settings");

        DrawTexture(editor, _MainTex, _Color);

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("GroupBox");

        Header("Shader Settings");

        editor.ShaderProperty(_rcolor, MakeLabel(_rcolor));
        editor.ShaderProperty(_gcolor, MakeLabel(_gcolor));
        editor.ShaderProperty(_Pulsatepower, MakeLabel(_Pulsatepower));
        editor.ShaderProperty(_Pulsatespeed, MakeLabel(_Pulsatespeed));
        GUILayout.Space(10);
        editor.ShaderProperty(_pcolor, MakeLabel(_pcolor));
        editor.ShaderProperty(_pgcolor, MakeLabel(_pgcolor));
        editor.ShaderProperty(_Pulsatepower2, MakeLabel(_Pulsatepower2));
        editor.ShaderProperty(_Pulsatespeed, MakeLabel(_Pulsatespeed2));
        GUILayout.Space(10);
        editor.ShaderProperty(_totalspeed, MakeLabel(_totalspeed));

        EditorGUILayout.EndVertical();

        DrawBanner("Patreon", "Open Patreon", "https://www.patreon.com/dopestuff");

        DrawCredits();
    }

    private void DrawTexture(MaterialEditor editor, MaterialProperty tex, MaterialProperty Color = null)
    {
        GUILayout.Space(3);
        GUIContent MainTexLabel = new GUIContent(tex.displayName);
        editor.TexturePropertySingleLine(MainTexLabel, tex, Color);
        editor.TextureScaleOffsetProperty(tex);
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
        _MainTex = FindProperty("_MainTex", properties);
        _Color = FindProperty("_Color", properties);
        _rcolor = FindProperty("_rcolor", properties);
        _pcolor = FindProperty("_pcolor", properties);
        _gcolor = FindProperty("_gcolor", properties);
        _pgcolor = FindProperty("_pgcolor", properties);
        _Pulsatepower = FindProperty("_Pulsatepower", properties);
        _Pulsatespeed = FindProperty("_Pulsatespeed", properties);
        _Pulsatepower2 = FindProperty("_Pulsatepower2", properties);
        _Pulsatespeed2 = FindProperty("_Pulsatespeed2", properties);
        _totalspeed = FindProperty("_totalspeed", properties);
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

    private static Color ColorField(string name, Color ColorValue, bool alpha = false)
    {
        var result = EditorGUILayout.ColorField(new GUIContent(name), ColorValue, false, alpha, true, new ColorPickerHDRConfig(0f, 65536f, 0f, 65536f));
        return result;
    }
}
#endif