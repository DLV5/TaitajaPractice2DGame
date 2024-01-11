using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(OrderUI))]
public class Order : MonoBehaviour
{
    public int[] CurrentCustomerOrderId {  get; private set; }

    private List<int> _playerChoises;

    private OrderUI _orderUI;

    private void Awake()
    {
        _orderUI = GetComponent<OrderUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GetNextCustomer();
    }

    public void AddChoice(int choice)
    {
        if (!_playerChoises.Contains(choice))
        {
            _playerChoises.Add(choice);
        } else
        {
            _playerChoises.Remove(choice);
        }

        _orderUI.ShowPlayerChoices(_playerChoises);
    }

    public void DebugOrders()
    {
        foreach (var item in _playerChoises)
        {
            Debug.Log(item);
        }
        Debug.Log($"The result of comparison is {CompareOrders()}");
    }

    public void OnOrderComplited()
    {
        if (!CompareOrders())
        {
            return;
        }
            GetNextCustomer();
    }

    /// <summary>
    /// Compares player choises and required customer order
    /// </summary>
    /// <returns></returns>
    private bool CompareOrders()
    {
        if (_playerChoises.Count != CurrentCustomerOrderId.Length)
        {
            Debug.Log("Arrays are not the same length");
            return false;
        }

        _playerChoises = _playerChoises.OrderBy(x => x).ToList();
        CurrentCustomerOrderId = CurrentCustomerOrderId.OrderBy(x => x).ToArray();

        for (int i = 0; i < CurrentCustomerOrderId.Length; i++)
        {
            if (CurrentCustomerOrderId[i] != _playerChoises[i])
            {
                Debug.Log($"Product {CurrentCustomerOrderId[i]} not equal with {_playerChoises[i]}");
                return false;
            }
        }

        return true;
    }

    private void GetNextCustomer()
    {
        //Have to pay attention to this line of code POSSIBLY CAN CAUSE PROBLEMS WITH SELECTION GRAPHICS ON FUTURE
        _playerChoises = new List<int>();

        CurrentCustomerOrderId = OrderGenerator.GetNextOrder();

        _orderUI.ShowCustomerOrder(CurrentCustomerOrderId);

        foreach (int c in CurrentCustomerOrderId)
        {
            Debug.Log(c);
        }
    }

}
