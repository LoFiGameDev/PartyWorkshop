using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

public static class Program
{
    public static bool testValue;
    public static int testNumber;
    public static string? testString;
    public static ReferenceType bla;

    static void Main(string[] args)
    {
        Console.WriteLine("----- Parameter -----");

        #region Parameter

        testValue = false;
        testNumber = 4;
        testString = "Ehmmmmmmmm Ja";
        bla = new ReferenceType();
        bla.Value = false;

        Console.WriteLine($"Bool: {testValue}, Int: {testNumber}, String: {testString}, RefType: {bla.Value}");

        Parameter.OnlyValueTypes(testValue, testNumber);

        Console.WriteLine($"Bool: {testValue}, Int: {testNumber}, String: {testString}, RefType: {bla.Value}");

        Parameter.ValueAndReferenceType(testString, bla);

        Console.WriteLine($"Bool: {testValue}, Int: {testNumber}, String: {testString}, RefType: {bla.Value}");

        Parameter.ForcedRef(ref testString);

        Console.WriteLine($"Bool: {testValue}, Int: {testNumber}, String: {testString}, RefType: {bla.Value}");

        //string num;
        Parameter.OutParamter("Es ist: ", out string num);

        Console.WriteLine(num);

        Parameter.OptionalParameters();
        Parameter.OptionalParameters("Moin", 8, false);
        Parameter.OptionalParameters(value: 9);
        Parameter.OptionalParameters(value: 9, bValue: true, op1: "googoo");

        #endregion

        Console.WriteLine("----- Enums -----");

        #region Enums

        SAERoom currentRoom = SAERoom.Eimsbüttel;

        if (currentRoom == SAERoom.StPauli)
        {
            Console.WriteLine("Wow das stimmt ja sogar");
        }
        else
        {
            Console.WriteLine("Du dummer Lügner");
        }

        switch (currentRoom)
        {
            case 0:
                break;
            case SAERoom.Eimsbüttel:
                break;
            case SAERoom.Altona:
                break;
            case SAERoom.Barmbek:
                break;
            default:
                break;
        }

        for (SAERoom i = 0; i <= SAERoom.Barmbek; i++)
        {
            Console.WriteLine(i + " ");
        }

        Direction direction = Direction.Up; // Enum value setzen

        direction |= Direction.Up | Direction.Down; // |= fügt value hinzu (flaggt ihn), | kettet mehrere (geht auch einzeln)

        Console.WriteLine((int)direction);

        direction &= ~Direction.Up; // &= und ~ nimmt value raus (removed flag)

        Console.WriteLine((int)direction);
        #endregion

        Console.WriteLine("----- Try-Catch-Finally -----");

        #region tcf

        Console.WriteLine("GIB EINE ZAHL EIN WEHE DU MACHST NEN BUCHSTABEN!!!!!");
        int inputNumber = 0;

        try
        {
            inputNumber = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            //switch (e)
            //{
            //    case IOException:
            //        break;

            //    case OutOfMemoryException:
            //        break;

            //    default:
            //        break;
            //}

            inputNumber = -1;
            Console.WriteLine("DU LAPPEN!! " + e.Message);
        }
        finally
        {
            Console.WriteLine(inputNumber == -1 ? "DAS WAR KEINE ZAHL!!!!" : "Ey danke bruder");
        }

        #endregion

        Console.WriteLine("----- Coole Datentypen -----");

        #region Data Types

        // Dictionary <TKey, TValue>
        // Stack <T> LIFO
        // Queue <T> FIFO
        // List <T>
        // Arrays <T>
        // HashSets
        // HashTable

        /*
         * public struct EnumObjectBundle <- als struct
         * {
         *      public Enum "Key"
         *      public GameObject "Value"
         * }
         * 
         * public EnumObjectBundle[] bundle; <- In MonoBehaviour
         * public Dictionary<Enum, GameObject> goDict; <- In MonoBehaviour
         * 
         * for (int i = 0; i < bundle.Length; i++)
         * {
         *      goDict.Add(bundle[i].Key, bundle[i].Value);
         * }
         * 
         * public GameObject GetObject(Enum value)
         * {
         *      return goDict[value];
         * }
         * 
         */

        Hashtable table = new Hashtable();

        table.Add(5, "habibi");
        table.Add(false, SAERoom.Altona);
        table.Add(true, SAERoom.Eimsbüttel);
        //table.Add(null, SAERoom.StPauli);

        Console.WriteLine(table[5]);
        Console.WriteLine(table[false]);
        Console.WriteLine(table[true]);
        //Console.WriteLine(table[null]); // GEHT NIT

        for (bool i = false; i == false; i = !i)
        {
            Console.WriteLine(table[i]);
        }

        HashSet<int> intSet = new HashSet<int>();

        intSet.Add(9);

        if (intSet.TryGetValue(9, out int outOfSet))
        {
            Console.WriteLine(outOfSet);
        }

        #endregion
    }

    public static void Iterate<T>() where T : ICollection<T>
    {
        for (int i = 0; i < 5; i++)
        {

        }
    }

    public enum SAERoom
    {
        StPauli,
        Eimsbüttel,
        Altona,
        Barmbek,
    }

    [Flags]
    public enum Direction
    {
        Up = 1,     //0001
        Right = 2,  //0010
        Down = 4,   //0100
        Left = 8,   //1000

        // UP-DOWN      //0101
        // LEFT-RIGHT   //1010
        // ALL          //1111
    }
}
