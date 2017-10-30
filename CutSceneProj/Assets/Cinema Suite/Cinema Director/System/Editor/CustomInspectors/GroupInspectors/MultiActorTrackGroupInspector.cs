﻿using UnityEditor;
using UnityEngine;
using CinemaDirector;
using CinemaDirectorControl.Utility;

/// <summary>
/// A custom inspector for a cutscene.
/// </summary>
[CustomEditor(typeof(MultiActorTrackGroup), true)]
public class MultiActorTrackGroupInspector : Editor
{
    //private SerializedProperty actors;

    private bool isShowdic = false;
    #region Language;

    GUIContent addTrackContent = new GUIContent("Add New Track", "Add a new track to this multi-actor track group.");
    GUIContent showdic = new GUIContent("显示详细信息", "显示详细信息 主要是显示隐藏的序列化数据方便查看数据");
    GUIContent noShowdic = new GUIContent("隐藏详细信息", "隐藏详细信息 主要是显示隐藏的序列化数据方便查看数据");
    #endregion

    /// <summary>
    /// On inspector enable, load the serialized properties
    /// </summary>
    private void OnEnable()
    {
        //this.actors = base.serializedObject.FindProperty("actors");
    }

    /// <summary>
    /// Draw the inspector
    /// </summary>
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();

        MultiActorTrackGroup multiActorGroup = base.serializedObject.targetObject as MultiActorTrackGroup;

        //base.serializedObject.Update();

        //EditorGUILayout.PropertyField(actors, actorsContent);

        if (GUILayout.Button(addTrackContent))
        {
            CutsceneControlHelper.ShowAddTrackContextMenu(multiActorGroup);
        }

        if (isShowdic ? GUILayout.Button(noShowdic) : GUILayout.Button(showdic))
        {
            isShowdic = !isShowdic;
        }
        //base.serializedObject.ApplyModifiedProperties();

        if (isShowdic) base.OnInspectorGUI();

    }
}