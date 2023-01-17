using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal abstract class Animal<T> where T : Enum
{
    public CryType Cry;

    public Animal()
    {
        Cry = (CryType)T;
    }

    public virtual void WarCry(T cry)
    {
        switch (cry)
        {
            default:
                break;
        }
    }
}

public enum CryType
{
    Wal,
    Delfin,
    Spinne,
    Hund,
    Katze,
    Maus
}