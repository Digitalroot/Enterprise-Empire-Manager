using System;
using System.Collections.Generic;

namespace EEM.Common.Adapters
{
  class LoUAdapterDB
  {
    private readonly DBAdapter _dbAdapter;

    public LoUAdapterDB()
    {
      _dbAdapter = DBAdapter.Instance;
    }

    public City Load(int id)
    {
      var sql = _dbAdapter.DBConnection.CreateCommand();
      sql.CommandText = string.Format("SELECT value FROM eem_cities where server = '{0}' AND id = {1}", LoUAdapter.Instance.ServerName, id);
      var result = _dbAdapter.ExecuteScalar(sql);

      if (String.IsNullOrEmpty(result))
      {
        return null;
      }
      return Newtonsoft.Json.JsonConvert.DeserializeObject<City>(result);
    }

    public void Save(City city)
    {
      var sCity = Newtonsoft.Json.JsonConvert.SerializeObject(city);
      var dictionary = new Dictionary<string, string> { { "id", city.Id.ToString() }, { "value", sCity }, { "server", LoUAdapter.Instance.ServerName } };

      if (!_dbAdapter.Update("eem_cities", dictionary, String.Format("id = {0}", city.Id)))
      {
        _dbAdapter.Insert("eem_cities", dictionary);
      }
    }
  }
}
