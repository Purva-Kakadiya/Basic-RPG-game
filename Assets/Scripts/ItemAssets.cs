using UnityEngine;

public class ItemAssets : MonoBehaviour {
    public static ItemAssets Instance;

    public Sprite swordSprite;
    public Sprite daggerSprite;
    public Sprite armorSprite;
    public Sprite potionSprite;

    private void Awake() {

        Instance = this;
    }
}