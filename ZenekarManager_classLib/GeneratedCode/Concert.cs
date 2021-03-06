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

public class Concert
{
    private int koncert_id;

    public int Koncert_id
    {
        get { return koncert_id; }
        set { koncert_id = value; }
    }


    private string idopont;

    public string Idopont
    {
        get { return idopont; }
        set { idopont = value; }
    }


    private string vege;

    public string Vege
    {
        get { return vege; }
        set { vege = value; }
    }


    private string helyszin;

    public string Helyszin
    {
        get { return helyszin; }
        set { helyszin = value; }
    }


    private string megjegyzes;

    public string Megjegyzes
    {
        get { return megjegyzes; }
        set { megjegyzes = value; }
    }


    private int koncertfelelos;

    public int Koncertfelelos
    {
        get { return koncertfelelos; }
        set { koncertfelelos = value; }
    }


    private List<KeyValuePair<int, KeyValuePair<bool, string>>> tervezett_reszvetel;

    public List<KeyValuePair<int, KeyValuePair<bool, string>>> Tervezett_reszvetel
    {
        get { return tervezett_reszvetel; }
        set { tervezett_reszvetel = value; }
    }

    private List<KeyValuePair<int, bool>> resztvett;

    public List<KeyValuePair<int, bool>> Resztvett
    {
        get { return resztvett; }
        set { resztvett = value; }
    }

    private ConcertDaO concertDaO;


    public Concert()
    {
        concertDaO = new ConcertDaO();
        tervezett_reszvetel = new List<KeyValuePair<int, KeyValuePair<bool, string>>>();
        resztvett = new List<KeyValuePair<int, bool>>();
        koncert_id = -1;

    }


    public Concert(string helyszin, string idopont, int koncertfelelos, int koncert_id, string megjegyzes, 
        List<KeyValuePair<int, KeyValuePair<bool, string>>> tervezett_reszvetel , List<KeyValuePair<int, bool>> resztvett, string vege)
    {
        concertDaO = new ConcertDaO();
        tervezett_reszvetel = new List<KeyValuePair<int, KeyValuePair<bool, string>>>();
        resztvett = new List<KeyValuePair<int, bool>>();

        this.helyszin = helyszin;
        this.idopont = idopont;
        this.koncertfelelos= koncertfelelos;
        this.koncert_id = koncert_id;
        this.megjegyzes = megjegyzes;
        this.tervezett_reszvetel = tervezett_reszvetel;
        this.resztvett = resztvett;
        this.vege = vege;
    }


	public List<ConcertMaterial> getAllMaterial()
	{
        var data = new List<int>();
        var result = new List<ConcertMaterial>();

        data = concertDaO.getAllMaterial(koncert_id);
        
        for (int i=0; i<data.Count; i++) 
        {
            var material = new ConcertMaterial();
            if (material.read(data[i]))
            {
                result.Add(material);
            }
            
        }

        return result;
	}


	public bool deleteMaterial(int koncertanyag_id)
	{
        return concertDaO.deleteMaterialdata(koncertanyag_id);
	
	}


    public bool deleteAllMaterial()
    {
        return concertDaO.deleteAllMaterialdata(concertDaO.getAllMaterial(koncert_id));
    }


	public ConcertMaterial getMaterial(int koncertanyag_id)
	{
        var material = new ConcertMaterial();
        material.read(koncertanyag_id);
       
        return material;
	}


	public bool create()
	{
        koncert_id = concertDaO.writeConcertdata(helyszin, idopont, koncertfelelos, koncert_id, megjegyzes, tervezett_reszvetel, resztvett, vege);
        if (koncert_id>-1) 
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
        return concertDaO.modifyConcertdata(helyszin, idopont, koncertfelelos, koncert_id, megjegyzes, tervezett_reszvetel, resztvett, vege);
	}


	public List<Part> getUsersParts(int users_id)
	{
        var data = new List<int>();
        var result = new List<Part>();

        data = concertDaO.getUsersParts(users_id, koncert_id);

        for (int i = 0; i < data.Count; i++)
        {
            var szolam = new Part();
            if (szolam.readPart(data[i]))
            {
                result.Add(szolam);
            }
            
        }

        return result;
	}


	public KeyValuePair<bool, string> getTervezettReszvetel(int users_id)
	{
        return concertDaO.getTervezettReszvetel(users_id, koncert_id);
	}


	public bool getReszvetel(int users_id)
	{
        return concertDaO.getReszvetel(users_id, koncert_id);
	}


	public bool modifyReszvetel(int users_id, bool resztvesz, string indoklas)
	{
        return concertDaO.modifyReszvetel(users_id, resztvesz, indoklas, koncert_id);
	}


	public bool read(int koncert_id)
	{
		var data = new string[6];
        data = concertDaO.readConcertdata(koncert_id, ref tervezett_reszvetel, ref resztvett);

        this.koncert_id = Convert.ToInt32(data[0]);
        this.idopont = data[1];
        this.vege = data[2];
        this.helyszin = data[3];
        this.megjegyzes = data[4];
        this.koncertfelelos = Convert.ToInt32(data[5]);

        return true;
	}


	public List<KeyValuePair<int, KeyValuePair<bool, string> > > getAllTervezettReszvetel()
	{
        return concertDaO.getAllTervezettReszvetel(koncert_id);
	}


	public List<KeyValuePair<int, bool> > getAllReszvetel()
	{
        return concertDaO.getAllReszvetel(koncert_id);
	}

}

