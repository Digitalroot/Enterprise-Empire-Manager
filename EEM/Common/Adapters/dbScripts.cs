using System.Collections.Generic;

namespace EEM.Common.Adapters
{
  static class DBScripts
  {
    public static List<string> Scripts
    {
      get { return GetScripts(); }
    }

    private static List<string> GetScripts()
    {
      var list = new List<string>();

      // 1 - Update database version to two
      list.Add("UPDATE eem_db_config Set value = 2 where key = 'eem_db_config'");

      // 2 - Add the city table.
      list.Add("CREATE TABLE eem_cities(id int UNIQUE , value TEXT)");

      list.Add("ALTER TABLE eem_cities Add server TEXT");

      return list;
    }
  }
}
