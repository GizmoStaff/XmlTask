

using System.Xml;

internal class Program
{
    public static void SortNPrintElements(List<int> itemList)
    {
        int tempSpot;
         for(int i = 0; i < itemList.Count-1; i++)
        {
            for(int j = i+1; j < itemList.Count; j++)
            {
                if (itemList[i] > itemList[j]) { 
                tempSpot = itemList[i];
                itemList[i] = itemList[j];
                itemList[j] = tempSpot;
                }
            }
        }

        Console.WriteLine("Elements in ascending way.");
        
        foreach (var item in itemList)
        {
            Console.WriteLine(item);
        }
     
        
    }

    private static void Main(string[] args)
    {
        var reader = XmlReader.Create("Testfile.xml");

        reader.MoveToContent();

        List<int> itemList = new List<int>();

        while (reader.Read())
        {
            if (reader.NodeType == XmlNodeType.Text && !reader.IsEmptyElement)
            {
                try { 
                itemList.Add(Convert.ToInt32(reader.Value)); }
                catch {
                    Console.WriteLine("An error occured!");
                }
            }
        }

        Console.WriteLine($"Number of elements in the list is: {itemList.Count}.");


        /*
        // sorting elements with Sort() method
        itemList.Sort();

        foreach (var item in itemList)
        {
            Console.WriteLine(item);
        }*/


        SortNPrintElements(itemList);

    }
}