﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Log
{
    private LogDaO logDaO;

    public bool add(int users_id, string muvelet, string idopont, string uzenet)
    {
        return logDaO.adddata(users_id, muvelet, idopont, uzenet);
    }

}

