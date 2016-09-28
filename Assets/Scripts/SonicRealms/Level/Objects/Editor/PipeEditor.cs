﻿using System.Linq;
using SonicRealms.Core.Utils.Editor;
using UnityEditor;

namespace SonicRealms.Level.Objects.Editor
{
    [CustomEditor(typeof(Pipe))]
    public class PipeEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            if (targets.Count() > 1)
            {
                DrawDefaultInspector();
            }
            else
            {
                RealmsEditorUtility.DrawProperties(serializedObject, "TravelSpeed", "ExitSpeed",
                    "EntryPoint", "Path", "DisablePathCollider", "NeverUpdate");

                var neverUpdate = serializedObject.FindProperty("NeverUpdate");
                if (!neverUpdate.boolValue)
                {
                    RealmsEditorUtility.DrawProperties(serializedObject, "AlwaysUpdate");
                }
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
