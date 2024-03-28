using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[CreateAssetMenu(menuName = "ClickerProject/Item")]
public class Item : ScriptableObject
{
    

    [Header("Only gameplay")]
    public TileBase tile;
    
    public int id;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

    [Header("ItemType")]
    public CustomInspectorObjectsTool customInspectorObjectsTool;
}

public enum ItemType
{
    Useable,
    Tool,
    Poison
}

[System.Serializable]
public class CustomInspectorObjectsTool
{
    public ItemType type;
    //Usable
    [HideInInspector] public float damage = 3f;
    [HideInInspector] public float cooldown = 0.35f;

    //Tool
    [HideInInspector] public string  toolCategory = "Default";
    [HideInInspector] public float effectCooldown = 0.35f;

    //Poison
    [HideInInspector] public string  poisonType = "Default";
    [HideInInspector] public float poisonCooldown = 0.35f;
}

[CustomEditor(typeof(Item))]
public class MyItemScriptEditor : Editor
{
    Item itemTypeChooser;

    private void OnEnable()
    {
        itemTypeChooser = (Item)target;
    }

   public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if(itemTypeChooser.customInspectorObjectsTool.type == ItemType.Useable)
        {
            itemTypeChooser.customInspectorObjectsTool.damage = EditorGUILayout.FloatField("Damage", itemTypeChooser.customInspectorObjectsTool.damage);
            itemTypeChooser.customInspectorObjectsTool.cooldown = EditorGUILayout.FloatField("Cooldown", itemTypeChooser.customInspectorObjectsTool.cooldown);
        }
        else if(itemTypeChooser.customInspectorObjectsTool.type == ItemType.Tool)
        {
            itemTypeChooser.customInspectorObjectsTool.toolCategory = EditorGUILayout.TextField("Category", itemTypeChooser.customInspectorObjectsTool.toolCategory);
            itemTypeChooser.customInspectorObjectsTool.effectCooldown = EditorGUILayout.FloatField("Effect Cooldown", itemTypeChooser.customInspectorObjectsTool.effectCooldown);
        }
        else if(itemTypeChooser.customInspectorObjectsTool.type == ItemType.Poison)
        {
            itemTypeChooser.customInspectorObjectsTool.poisonType = EditorGUILayout.TextField("Type", itemTypeChooser.customInspectorObjectsTool.poisonType);
            itemTypeChooser.customInspectorObjectsTool.poisonCooldown = EditorGUILayout.FloatField("Poison Cooldown", itemTypeChooser.customInspectorObjectsTool.poisonCooldown);

        }

        if(GUI.changed)
        {
            EditorUtility.SetDirty(itemTypeChooser);
        }
    }
}