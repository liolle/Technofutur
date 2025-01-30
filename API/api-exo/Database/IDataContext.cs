using Microsoft.Data.SqlClient;

namespace apiExo.database;

public interface IDataContext {
    SqlConnection CreateConnection();
}