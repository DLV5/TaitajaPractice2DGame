using System.Linq;
using UnityEngine;

public static class OrderGenerator
{
    public static int maxAmountOfItemsInOrder = 3;
    public static int mixAmountOfItemsInOrder = 1;

    private static int[] _products;

    private static int _amountOfItensInOrder;

    /// <summary>
    /// This method generates new order
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    public static int[] GetNextOrder()
    {
         _amountOfItensInOrder = Random.Range(mixAmountOfItemsInOrder, maxAmountOfItemsInOrder);
        _products = new int[_amountOfItensInOrder];
        //Replase with productData later
        return _products.Select(x => Random.Range(1, 6)).ToArray();
    }

}
