using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class Parameter
{
    /// <summary>
    /// Das ist eine Methode.
    /// Diese Methode hat PARAMETER (einen bool und einen integer, nur value types)
    /// Beim Aufrufen der Methode müssen diese Parameter übergeben werden.
    /// Diese werden dann (bei value types) kopiert und bei reference types übernommen.
    /// </summary>
    public static void OnlyValueTypes(bool value, int number)
    {
        value = !value;
        number *= number;
    }

    /// <summary>
    /// Selbes wie oben, aber mit string (value type) und ReferenceType (eigene Klasse).
    /// </summary>
    public static void ValueAndReferenceType(string value, ReferenceType refType) 
    {
        value += " wow";
        refType.Value = !refType.Value;
    }

    public static void ForcedRef(ref string value)
    {
        value += " wow";
    }

    public static bool OutParamter(string value, out string result)
    {
        result = value + " 9";

        return true;
    }

    public static void OptionalParameters(string op1 = "Hallo", int value = 5, bool bValue = true)
    {
        if (op1 == "Hallo") op1 = "Schüss";
        if (value == 5) value = 9001;
        if (bValue) bValue = false;

        Console.WriteLine($"Bool: {bValue}, Int: {value}, String: {op1}");
    }
}
