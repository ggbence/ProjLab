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

public class Manager : User
{
	protected ManagerDaO managerDaO = new ManagerDaO();
	

	public bool deleteUser(int users_id)
	{
        return managerDaO.deleteUserdata(users_id);
	}


	public bool changeUserRole(int users_id, int jogkod_id)
	{
        return managerDaO.changeRole(users_id, jogkor_id);
	}

    public List<User> getUserList()
    {
        return managerDaO.getUsers();
    }

	public List<KeyValuePair<int, string>> getRoles()
	{
        return managerDaO.getAllRole();
	}


	public bool changeUser(User user)
	{
        return user.profileModify();
	}


    public bool addInstruments(List<KeyValuePair< string, int>> hangszerlista) 
    {
        return managerDaO.newInstruments(hangszerlista);
    }


    public bool addInstrumentTypes(List<String> tipuslista)
    {
        return managerDaO.newInstrumentTypes(tipuslista);
    }


    public bool deleteInstrument(int hangszer_id)
    {
        return managerDaO.delInstrument(hangszer_id);
    }


    public bool deleteInstrumentType(int hangszertipus_id)
    {
        return managerDaO.delInstrumentType(hangszertipus_id);
    }


    public bool addConcert(Concert concert)
    {
        return concert.create();
    }


    public bool deleteConcert(int koncert_id)
    {
        var koncert = new Concert();
        if (koncert.read(koncert_id))
        {
            if (koncert.deleteAllMaterial())
            {
                if (managerDaO.deleteConcertdata(koncert_id))
                {
                    return true;
                }
            }
        }
        return false;
        

    }


    public bool addRehearsal(Rehearsal proba) 
    {
        return proba.create();
    }


    public bool deleteRehearsal(int proba_id) 
    {
        return managerDaO.deleteRehearsaldata(proba_id);
    }


    public bool addRehearsalMaterial(RehearsalMaterial probaanyag) 
    {
        return probaanyag.create();
    }


    public bool deleteRehearsalMaterial(int probaanyag_id) 
    {
        return managerDaO.deleteRehearsalMaterialdata(probaanyag_id);
    }


    public List<RehearsalMaterial> getAllInactiveRehearsalMaterial()
    {
        var data = new List<int>();
        var result = new List<RehearsalMaterial>();

        data = managerDaO.getAllInactiveRehearsalMaterial();
        for (int i = 0; i < data.Count; i++)
        {
            var material = new RehearsalMaterial();
            material.read(data[i]);
            result.Add(material);
        }

        return result;
    }
}

