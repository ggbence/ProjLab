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

public class Message
{
	private int kuldo;

    public int Kuldo
    {
      get { return kuldo; }
      set { kuldo = value; }
    }


	private string uzenet;

    public string Uzenet
    {
      get { return uzenet; }
      set { uzenet = value; }
    }

	private List<int> cimzett;

    public List<int> Cimzett
    {
      get { return cimzett; }
      set { cimzett = value; }
    }

	private string datum;

    public string Datum
    {
      get { return datum; }
      set { datum = value; }
    }

	private int uzenet_id;

    public int Uzenet_id
    {
      get { return uzenet_id; }
      set { uzenet_id = value; }
    }

	private string ervenyesseg;

    public string Ervenyesseg
    {
      get { return ervenyesseg; }
      set { ervenyesseg = value; }
    }

    public Message()
    {

    }

	public bool addRecipient(int rcp)
	{
		cimzett.Add(rcp);
        return true;
	}

    public bool delRecipient(int rcp)
    {
        cimzett.Remove(rcp);
        return true;
    }
}

