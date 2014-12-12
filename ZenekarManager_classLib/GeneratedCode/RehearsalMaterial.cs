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

public class RehearsalMaterial
{
    private int probaanyag_id;

    public int Probaanyag_id
    {
      get { return probaanyag_id; }
      set { probaanyag_id = value; }
    }


    private int tetel_id;

    public int Tetel_id
    {
      get { return tetel_id; }
      set { tetel_id = value; }
    }


    private bool probaanyag_aktiv;

    public bool Probaanyag_aktiv
    {
      get { return probaanyag_aktiv; }
      set { probaanyag_aktiv = value; }
    }


    private List<KeyValuePair<int, int>> zeneszek;

    public List<KeyValuePair<int, int>> Zeneszek
    {
      get { return zeneszek; }
      set { zeneszek = value; }
    }


    private RehearsalMaterialDaO rehearsalMaterialDaO;


    public RehearsalMaterial()
    {
        rehearsalMaterialDaO = new RehearsalMaterialDaO();
        zeneszek = new List<KeyValuePair<int, int>>();
    }


    public RehearsalMaterial(int tetel_id, bool probaanyag_aktiv, List<KeyValuePair<int, int>> zeneszek)
    {
        rehearsalMaterialDaO = new RehearsalMaterialDaO();
        zeneszek = new List<KeyValuePair<int, int>>();

        this.tetel_id = tetel_id;
        this.probaanyag_aktiv = probaanyag_aktiv;
        this.zeneszek = zeneszek;
    }


	public bool addZenesz(int users_id, int szolam_id)
	{
        if (rehearsalMaterialDaO.addZenesz(probaanyag_id, users_id, szolam_id))
        {
            zeneszek.Add(new KeyValuePair<int, int>(users_id, szolam_id));
            return true;
        }
        else
        {
            return false;
        }
	}


	public bool create()
	{
        probaanyag_id = rehearsalMaterialDaO.writeRehearsalMaterialdata(probaanyag_id, probaanyag_aktiv, tetel_id, zeneszek);
        if (probaanyag_id > -1)
        {
            return true;
        }
        else
        {
            return false;
        }
	}


	public bool deleteZenesz(int users_id, int szolam_id)
	{
        return rehearsalMaterialDaO.deleteZenesz(probaanyag_id, users_id, szolam_id);
	}


	public List<KeyValuePair<int, int>> getZeneszek()
	{
        return rehearsalMaterialDaO.getZeneszek(probaanyag_id);
	}


	public bool modify()
	{
        return rehearsalMaterialDaO.modifyRehearsalMaterialdata(probaanyag_id, probaanyag_aktiv, tetel_id, zeneszek);
	}


	public bool read(int probaanyag_id)
	{
        var data = new int[3];
        data = rehearsalMaterialDaO.readRehearsalMaterialdata(probaanyag_id, ref zeneszek);

        this.probaanyag_id = data[0];
        this.tetel_id = data[1];
        this.probaanyag_aktiv = (data[3] == 1 ? true : false);

        return true;

	}


	public bool activate()
	{
        return rehearsalMaterialDaO.activate(probaanyag_id);
	}


	public bool deactivate()
	{
        return rehearsalMaterialDaO.deactivate(probaanyag_id);
	}

}

