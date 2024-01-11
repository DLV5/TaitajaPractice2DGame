using UnityEngine;

[CreateAssetMenu(menuName = "Order/GoodsData")]
public class OrderImagesData : ScriptableObject
{
    [System.Serializable]
    public class Product
    {
        public int id;
        public GameObject picture;
    }

    public Product[] Products = new Product[] { };
}
