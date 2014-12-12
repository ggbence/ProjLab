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

public class ConcertMaterial
{
    private int koncertanyag_id;

    public int Koncertanyag_id
    {
        get { return koncertanyag_id; }
        set { koncertanyag_id = value; }
    }


    private int koncert_id;

    public int Koncert_id
    {
        get { return koncert_id; }
        set { koncert_id = value; }
    }


    private int sorszam;

    public int Sorszam
    {
        get { return sorszam; }
        set { sorszam = value; }
    }


    private int tetel_id;

    public int Tetel_id
    {
        get { return tetel_id; }
        set { tetel_id = value; }
    }


    private List<KeyValuePair<int, int>> zeneszek;

    public List<KeyValuePair<int, int>> Zeneszek
    {
        get { return zeneszek; }
        set { zeneszek = value; }
    }


    private ConcertMaterialDaO concertMaterialDaO;


    public ConcertMaterial()
    {
        concertMaterialDaO = new ConcertMaterialDaO();
        zeneszek = new List<KeyValuePair<int, int>>();

    }

    public ConcertMaterial(int koncert_id, int sorszam, int tetel_id, List<KeyValuePair<int, int>> zeneszek)
    {
        concertMaterialDaO = new ConcertMaterialDaO();
        zeneszek = new List<KeyValuePair<int, int>>();

        this.koncert_id = koncert_id;
        this.sorszam = sorszam;
        this.tetel_id = tetel_id;
        this.zeneszek = zeneszek;

    }


	public bool create()
	{
        koncertanyag_id = concertMaterialDaO.create(koncertanyag_id, koncertanyag_id, sorszam, tetel_id, zeneszek);
        if (koncertanyag_id > -1)
        {
            return true;
        }
        else
        {
            return false;
        }

	}


	public bool modify()
	{
        return concertMaterialDaO.modify(koncertanyag_id, koncert_id, sorszam, tetel_id, zeneszek);
	}


	public bool read(int koncertanyag_id)
	{
        var data = new int[4];
        data = concertMaterialDaO.read(koncertanyag_id, ref zeneszek);
        koncertanyag_id = data[0];
        koncert_id = data[1];
        sorszam = data[2];
        tetel_id = data[3];

        return true;
	}


	public bool addZenesz(int users_id, int szolam_id)
	{
        if (concertMaterialDaO.addZenesz(koncertanyag_id, users_id, szolam_id, koncert_id))
        {
            zeneszek.Add(new KeyValuePair<int, int>(users_id, szolam_id));
            return true;
        }
        else
        {
            return false;
        }
	}


	public List<KeyValuePair<int, int>> getZeneszek()
	{
        return concertMaterialDaO.getZeneszek(koncertanyag_id);
	}

	public bool deleteZenesz(int users_id, int szolam_id)
	{
        return concertMaterialDaO.deleteZenesz(koncertanyag_id, users_id, szolam_id);
	}

    

}

