using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;

namespace EEM.Common.Adapters
{
  public sealed class DBAdapter
  {
    /// <summary>
    /// Singleton Instance
    /// </summary>
    private static volatile DBAdapter _instance;

    /// <summary>
    /// Lock to make thread safe.
    /// </summary>
    private static readonly object SyncRoot = new Object();

    /// <summary>
    /// Singleton
    /// </summary>
    public static DBAdapter Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (SyncRoot)
          {
            if (_instance == null)
              _instance = new DBAdapter();
          }
        }
        return _instance;
      }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    private DBAdapter()
    {
      DBConnection = new SQLiteConnection("Data Source=|DataDirectory|\\eem.db");
      CreateOrUpdateDefaultTables();
    }

    /// <summary>
    /// 
    /// </summary>
    ~DBAdapter()
    {
      if (DBConnection.State != System.Data.ConnectionState.Closed)
      {
        DBConnection.Close();
      }
    }

    /// <summary>
    /// Creates the default config table.
    /// </summary>
    private void CreateDeafultTables()
    {
      var dbCommand = DBConnection.CreateCommand();
      dbCommand.CommandText = "CREATE TABLE eem_db_config(key TEXT UNIQUE , value TEXT)";
      ExecuteNonQuery(dbCommand);

      var dictionary = new Dictionary<string, string> {{"key", "eem_db_config"}, {"value", "0"}};

      Insert("eem_db_config", dictionary);
    }

    /// <summary>
    /// Connection to the database
    /// </summary>
    public DbConnection DBConnection { get; private set; }

    /// <summary>
    /// Creates the Default Config table.
    /// </summary>
    private void CreateOrUpdateDefaultTables()
    {
      if (!TableExists("eem_db_config"))
      {
        CreateDeafultTables();
      }

      var dbCommand = DBConnection.CreateCommand().CommandText = "SELECT value FROM eem_db_config WHERE key = 'eem_db_config'";
      var tableVersion = Int32.Parse(ExecuteScalar(dbCommand));

      RunUpDateScripts(tableVersion);

    }

    /// <summary>
    /// Runs all update scripts to update a database.
    /// </summary>
    /// <param name="tableVersion"></param>
    private void RunUpDateScripts(int tableVersion)
    {
      for (int i = tableVersion; i < DBScripts.Scripts.Count; i++)
      {
        ExecuteNonQuery(DBScripts.Scripts[i]);
      }
      var dictionary = new Dictionary<string, string> { { "value", DBScripts.Scripts.Count.ToString() } };

      Update("eem_db_config", dictionary, "key = 'eem_db_config'");
    }

    /// <summary>                                                                                                
    ///     Allows the programmer to easily delete rows from the DB.                                             
    /// </summary>                                                                                               
    /// <param name="tableName">The table from which to delete.</param>                                          
    /// <param name="where">The where clause for the delete.</param>                                             
    /// <returns>A Boolean true or false to signify success or failure.</returns>                                
    public bool Delete(String tableName, String where)
    {
      return ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where)) > 0;
    }

    /// <summary>
    /// Non-Select Statements. 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public int ExecuteNonQuery(string sql)
    {
      DbCommand dbCommand = DBConnection.CreateCommand();
      dbCommand.CommandText = sql;
      return ExecuteNonQuery(dbCommand);
    }

    /// <summary>
    /// Non-Select Statements. 
    /// </summary>
    /// <param name="dbCommand"></param>
    /// <returns></returns>
    public int ExecuteNonQuery(DbCommand dbCommand)
    {
      if (DBConnection.State != System.Data.ConnectionState.Open)
      {
        DBConnection.Open();
      }
      return dbCommand.ExecuteNonQuery();
    }

    /// <summary>                                                      
    /// Allows the programmer to retrieve single items from the DB.
    /// </summary>
    /// <returns>A string.</returns>       
    public string ExecuteScalar(string sql)
    {
      DbCommand dbCommand = DBConnection.CreateCommand();
      dbCommand.CommandText = sql;
      return ExecuteScalar(dbCommand);
    }

    /// <summary>                                                      
    /// Allows the programmer to retrieve single items from the DB.
    /// </summary>
    /// <param name="dbCommand"></param>
    /// <returns>A string.</returns>                                   
    public string ExecuteScalar(DbCommand dbCommand)
    {
      if (DBConnection.State != System.Data.ConnectionState.Open)
      {
        DBConnection.Open();
      }
      var value = dbCommand.ExecuteScalar();
      DBConnection.Close();
      return value != null ? value.ToString() : "";
    }

    /// <summary>                                                                                                
    ///     Allows the programmer to easily insert into the DB                                                   
    /// </summary>                                                                                               
    /// <param name="tableName">The table into which we insert the data.</param>                                 
    /// <param name="data">A dictionary containing the column names and data for the insert.</param>             
    /// <returns>A Boolean true or false to signify success or failure.</returns>                                
    public bool Insert(String tableName, Dictionary<String, String> data)
    {
      var columns = "";
      var values = "";
      foreach (KeyValuePair<String, String> val in data)
      {
        columns += String.Format(" {0},", val.Key);
        values += String.Format(" '{0}',", val.Value);
      }
      columns = columns.Substring(0, columns.Length - 1);
      values = values.Substring(0, values.Length - 1);

      return ExecuteNonQuery(String.Format("insert into {0} ({1}) values ({2});", tableName, columns, values)) > 0;
    } 

    /// <summary>
    /// Select Statements. 
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public DataTable Select(string sql)
    {
      DbCommand dbCommand = DBConnection.CreateCommand();
      dbCommand.CommandText = sql;
      return Select(dbCommand);
    }

    /// <summary>
    /// Select Statements. 
    /// </summary>
    /// <param name="dbCommand"></param>
    /// <returns></returns>
    public DataTable Select(DbCommand dbCommand)
    {
      var dataTable = new DataTable();
      try
      {
        if (DBConnection.State != System.Data.ConnectionState.Open)
        {
          DBConnection.Open();
        }
        DbDataReader dataReader = dbCommand.ExecuteReader();

        dataTable.Load(dataReader);
        dataReader.Close();
        DBConnection.Close();
      }
      catch (Exception e)
      {
        throw new Exception(e.Message);
      }
      return dataTable;                                                     
    }

    /// <summary>
    /// Check if a table exists
    /// </summary>
    /// <param name="tableName"></param>
    /// <returns></returns>
    public bool TableExists(string tableName)
    {
      var dbCommand = DBConnection.CreateCommand();
      dbCommand.CommandText = "SELECT name FROM sqlite_master WHERE type='table' ORDER BY name;";
      DataTable table = Select(dbCommand);

      return table.Rows.Cast<DataRow>().Where(row => row["name"].ToString() == tableName).Any();
    }

    /// <summary>                                                                                                
    ///     Allows the programmer to easily update rows in the DB.                                               
    /// </summary>                                                                                               
    /// <param name="tableName">The table to update.</param>                                                     
    /// <param name="data">A dictionary containing Column names and their new values.</param>                    
    /// <param name="where">The where clause for the update statement.</param>                                   
    /// <returns>A Boolean true or false to signify success or failure.</returns>                                
    public bool Update(String tableName, Dictionary<String, String> data, String where)
    {
      String vals = "";
      Boolean returnCode = true;
      if (data.Count >= 1)
      {
        vals = data.Aggregate(vals, (current, val) => current + String.Format(" {0} = '{1}',", val.Key, val.Value));
        vals = vals.Substring(0, vals.Length - 1);
      }

      try
      {
        var i = ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));

        if (i == 0)
        {
          returnCode = false;
        }
      }
      catch
      {
        returnCode = false;
      }
      return returnCode;
    }
  }
}
