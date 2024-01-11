using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private GameObject _customerOrderCloud;
    [SerializeField] private GameObject _playerChoicesCloud;

    [SerializeField] private OrderImagesData _data;

    private int[] _idOfimageToShowInOrderWindow;
    private int[] _idOfimageToShowInChoiceWindow;

    private List<GameObject> _allCustomerOrderImages = new List<GameObject>();
    private List<GameObject> _allPlayerChoicesImages = new List<GameObject>();

    private void Awake()
    {
        InitializeCustomerOrderImages();
        InitializePlayerChoicesImages();
    }

    public void ShowCustomerOrder(int[] orderArray)
    {
        if (_allCustomerOrderImages != null)
        {
            foreach (GameObject item in _allCustomerOrderImages)
            {
                item.SetActive(false);
            }
        }
        //I check id of the both arrays
        _idOfimageToShowInOrderWindow = orderArray.Where(x => ImageCheck(_data.Products, x)).Select(x => _data.Products[x].id).ToArray();

        foreach (int index in _idOfimageToShowInOrderWindow)
        {
            _allCustomerOrderImages[index].SetActive(true);
        }
    }

    public void ShowPlayerChoices(IEnumerable<int> orderArray)
    {
        if (_allPlayerChoicesImages != null)
        {
            foreach (GameObject item in _allPlayerChoicesImages)
            {
                item.SetActive(false);
            }
        }
        //I check id of the both arrays
        _idOfimageToShowInChoiceWindow = orderArray.Where(x => ImageCheck(_data.Products, x)).Select(x => _data.Products[x].id).ToArray();

        foreach (int index in _idOfimageToShowInChoiceWindow)
        {
            _allPlayerChoicesImages[index].SetActive(true);
        }
    }

    private void InitializeCustomerOrderImages()
    {
        foreach(OrderImagesData.Product item in _data.Products)
        {
            GameObject good = Instantiate(item.picture, new Vector2(0, 0), Quaternion.identity);

            good.transform.SetParent(_customerOrderCloud.transform);
            good.SetActive(false);

            _allCustomerOrderImages.Add(good);
        }
    }

    private void InitializePlayerChoicesImages()
    {
        foreach (OrderImagesData.Product item in _data.Products)
        {
            GameObject good = Instantiate(item.picture, new Vector2(0, 0), Quaternion.identity);

            good.transform.SetParent(_playerChoicesCloud.transform);
            good.SetActive(false);

            _allPlayerChoicesImages.Add(good);
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
