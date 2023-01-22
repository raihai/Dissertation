using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CubeSphere))]
public class PlanetEditor : Editor
{
    CubeSphere CubeSphere;
    Editor shapeEditor;
    Editor colourEditor;

    public override void OnInspectorGUI()
    {
        using (var check = new EditorGUI.ChangeCheckScope())
        {
            base.OnInspectorGUI();
            if (check.changed)
            {
                CubeSphere.GeneratePlanet();
            }
        }
        
        if (GUILayout.Button("Generate Planet"))
        {
            CubeSphere.GeneratePlanet();
        }

        DrawSettingsEditor(CubeSphere.shapeSettings, CubeSphere.OnShapeSettingsUpdated, ref CubeSphere.shapeSettingsFoldout, ref shapeEditor);
        DrawSettingsEditor(CubeSphere.colourSettings, CubeSphere.OnColourSettingsUpdate, ref CubeSphere.colourSettingsFoldout, ref colourEditor);

    }

    void DrawSettingsEditor(Object settings, System.Action onSettingsUpdated, ref bool foldout, ref Editor editor)
    {

        if (settings != null)
        {
            foldout = EditorGUILayout.InspectorTitlebar(foldout, settings);
            using (var check = new EditorGUI.ChangeCheckScope())
            {
                if (foldout)
                {
                    CreateCachedEditor(settings, null, ref editor);
                    editor.OnInspectorGUI();

                    if (check.changed)
                    {
                        if (onSettingsUpdated != null)
                        {
                            onSettingsUpdated();
                        }
                    }
                }

            }
        }
        
           
    }

    private void OnEnable()
    {
        CubeSphere = (CubeSphere)target;
    }

}
