using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private GameObject _customerOrderCloud;
    [SerializeField] private TMP_Text _playerChoicesText;

    [SerializeField] private OrderImagesData _data;

    private int[] _idOfimageToShowInOrderWindow;

    private List<GameObject> _allImages = new List<GameObject>();

    private void Awake()
    {
        InitializeImages();
    }

    public void ShowCustomerOrder(int[] orderArray)
    {
        if (_allImages != null)
        {
            foreach (GameObject item in _allImages)
            {
                item.SetActive(false);
            }
        }
        //I check id of the both arrays
        _idOfimageToShowInOrderWindow = orderArray.Where(x => ImageCheck(_data.Products, x)).Select(x => _data.Products[x].id).ToArray();

        foreach (int index in _idOfimageToShowInOrderWindow)
        {
            _allImages[index - 1].SetActive(true);
        }
    }

    public void ShowPlayerChoices(IEnumerable<int> orderArray)
    {
        _playerChoicesText.text = string.Join(" + ", orderArray);
    }

    private void InitializeImages()
    {
        foreach(OrderImagesData.Product item in _data.Products)
        {
            GameObject good = Instantiate(item.picture, new Vector2(0, 0), Quaternion.identity);

            good.transform.SetParent(_customerOrderCloud.transform);
            good.SetActive(false);

            _allImages.Add(good);
        }
    }

    private bool ImageCheck(OrderImagesData.Product[] orderArray, int requiredId)
    {
        foreach(OrderImagesData.Product product in orderArray)
        {
            if(product.id == requiredId)
            {
                return true;
            }
        }

        return false;
    }
}
