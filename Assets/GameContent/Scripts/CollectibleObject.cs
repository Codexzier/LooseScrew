using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class CollectibleObject : MonoBehaviour
{
    private void Awake()
    {
        if (!this.GetComponent<BoxCollider2D>().isTrigger)
        {
            Debug.LogError($"Fehler: {this.gameObject.name}");
        }
    }
}