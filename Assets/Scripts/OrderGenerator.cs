using System.Linq;

public static class OrderGenerator
{
    public static int maxAmountOfItemsInOrder = 3;
    public static int mixAmountOfItemsInOrder = 1;

    private static int[] _productsId;

    private static int _amountOfItensInOrder;

    /// <summary>
    /// This method generates new order
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    public static int[] GetNextOrder()
    {
         _amountOfItensInOrder = UnityEngine.Random.Range(mixAmountOfItemsInOrder, maxAmountOfItemsInOrder);
        _productsId = new int[_amountOfItensInOrder];
        return _productsId.Select(x => UnityEngine.Random.Range(1, 6)).Distinct().ToArray();
    }



}
