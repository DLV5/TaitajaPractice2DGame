using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Order : MonoBehaviour
{
    private List<int> _playerChoises;
    private int[] _currentCustomerOrder;
    
    // Start is called before the first frame update
    void Start()
    {
         _currentCustomerOrder = OrderGenerator.GetNextOrder();
        _playerChoises = new List<int>();

        foreach (int c in _currentCustomerOrder)
        {
            Debug.Log(c);
        }
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
        if (CompareOrders())
        {
            _currentCustomerOrder = OrderGenerator.GetNextOrder();

            foreach (int c in _currentCustomerOrder)
            {
                Debug.Log(c);
            }
        }
    }

    /// <summary>
    /// Compares player choises and required customer order
    /// </summary>
    /// <returns></returns>
    private bool CompareOrders()
    {
        if (_playerChoises.Count != _currentCustomerOrder.Length)
        {
            Debug.Log("Arrays are not the same length");
            return false;
        }

        _playerChoises = _playerChoises.OrderBy(x => x).ToList();
        _currentCustomerOrder = _currentCustomerOrder.OrderBy(x => x).ToArray();

        for (int i = 0; i < _currentCustomerOrder.Length; i++)
        {
            if (_currentCustomerOrder[i] != _playerChoises[i])
            {
                Debug.Log($"Product {_currentCustomerOrder[i]} not equal with {_playerChoises[i]}");
                return false;
            }
        }

        return true;
    }

}
