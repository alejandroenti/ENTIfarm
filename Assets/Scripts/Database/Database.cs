using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Database : MonoBehaviour
{

    public static Database _DATABASE;

    // Database variables
    private IDbConnection conn;
    private string dbName = "Assets/SQL/entifarm.db";

    // Objects variables
    private List<Plant> plants;

    private void Awake()
    {
        if (_DATABASE != null && _DATABASE != this)
        {
            Destroy(this);
        }
        else
        {
            _DATABASE = this;
            DontDestroyOnLoad(this);

            conn = new SqliteConnection(string.Format("URI=file:{0}", dbName));
            conn.Open();

            plants = new List<Plant>();
        }

        GetAllPlants();
    }

    public List<Plant> GetPlants() => plants;

    private List<Plant> GetAllPlants()
    {
        // Miramos si el array est� vac�o. En caso que no est�, retornamos el array
        if (plants.Count != 0)
        {
            return plants;
        }

        // Nos conectamos a la base de datos y ejecutamos el comando de recibir todas las plantas
        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM plants;";
        IDataReader reader = cmd.ExecuteReader();


        // Mientras tengamos ROWS que leer, almacenamos los datos en un array, encapsulado en el objecto Plant
        while (reader.Read())
        {
            plants.Add(new Plant(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetFloat(5)));
        }

        return plants;
    }

    public List<Plant> GetUserPlants()
    {
        // Generamos la variable de la lista a retornar
        List<Plant> userPlants = new List<Plant>();

        // Nos conectamos a la base de datos y ejecutamos el comando de recibir todas las plantas
        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT plants.id_plant, plants.plant, plants.time, plants.quantity * COUNT(*) as total_quantity, plants.sell, plants.buy FROM plants_users LEFT JOIN plants ON plants.id_plant = plants_users.id_plant WHERE plants_users.id_user = 1 GROUP BY plants.id_plant;";
        IDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            userPlants.Add(new Plant(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetFloat(5)));
        }

        return userPlants;
    }

    public void BuyPlant(int idPlant)
    {
        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "INSERT INTO plants_users (id_plant, id_user) VALUES (" + idPlant + ", " + GameManager._GAMEMANAGER.GetUsderID() + ");";
        cmd.ExecuteReader();
    }

    public void SaveGame(float gameTime, float currency, GameObject crops)
    {
        IDbCommand cmd = conn.CreateCommand();

  
        
            //UPDATE savedgames SET time = 7.30, money = 60, saved = CURRENT_TIMESTAMP WHERE savedgames.id_user = 1;
            cmd.CommandText = "UPDATE savedgames SET time = " + gameTime.ToString().Replace(",", ".") + ", money = " + currency + ", saved = CURRENT_TIMESTAMP WHERE savedgames.id_user = 1;";
            cmd.ExecuteNonQuery();
            Debug.Log("Game Settings Saved!");
        

        for (int i = 0; i < crops.transform.childCount; i++)
        {
            string plantID = "NULL";

            if (crops.transform.GetChild(i).GetChild(0).GetComponent<CropGrow>().GetPlant() != null) {
                plantID = crops.transform.GetChild(i).GetChild(0).GetComponent<CropGrow>().GetPlant().GetPlantID().ToString();
            }


                // UPDATE savedgames_cells SET time = 23, id_plant = 1 WHERE savedgames_cells.id_savedgame = 1 AND savedgames_cells.x = 2 AND savedgames_cells.y = 3;
                cmd.CommandText = "UPDATE savedgames_cells SET time = " + crops.transform.GetChild(i).GetChild(0).GetComponent<CropGrow>().GetCropGrowTimer().ToString().Replace(",", ".") + ", id_plant = " + plantID + " WHERE savedgames_cells.id_savedgame = " + GameManager._GAMEMANAGER.GetSaveID() + " AND savedgames_cells.x = " + (int)i / 5 + " AND savedgames_cells.y = " + i % 5 + ";";
                cmd.ExecuteNonQuery();
                Debug.Log("Cell " + (int)i / 5 + ", " + i % 5 + " Saved!");
            
        }

        Debug.Log("Game Saved");
    }
}
