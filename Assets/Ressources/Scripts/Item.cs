using UnityEngine;

[CreateAssetMenu(fileName = "Nouvel objet", menuName = "Inventaire/Créer un objet")]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite icon;
    public string description;
    public GameObject sceneObject;
    public int unlocked;

    public void Awake()
    {
        unlocked = PlayerPrefs.GetInt("Lock" + name);
    }


}