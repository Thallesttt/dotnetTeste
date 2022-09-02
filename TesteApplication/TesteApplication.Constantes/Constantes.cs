using k8s;
using Newtonsoft.Json;
using System.Reflection;

namespace TesteApplication.Constantes
{
    public static class ConstantesModel
    {

        public static async Task<String> recoverStringConection()
        {
            DataBase data = null;
            try
            {


                using (StreamReader file = new StreamReader("DataBasesConfig.json"))
                {
                    var text = file.ReadToEnd();
                    bool yaml = false;
                    //YAML File Config
                    if (yaml)
                    {
                        //var ObjYaml = KubernetesYaml.Deserialize<Object>(text);
                        data = KubernetesYaml.Deserialize<DataBase>(text);
                    }

                    //var ObjJson = JsonConvert.DeserializeObject<Object>(text);
                    data = JsonConvert.DeserializeObject<DataBase>(text);

                    return DataBase.GetStringConnection(data.Connection);

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

    }
    interface IDataBase
    {
        public Connection? Connection { get; set; }
        public string? DataBaseName { get; set; }
    }
    public class DataBase : IDataBase
    {
        public static string GetStringConnection(Connection conn)
        {
            string text = "";
            List<PropertyInfo> connFields = conn.GetType().GetProperties().ToList();
            connFields.ForEach(prop =>
            {
                if (prop.Name == "User")
                {
                    text += "User Id" + "=" + prop.GetValue(conn) + ";";
                }
                else
                {
                    text += prop.Name + "=" + prop.GetValue(conn) + ";";
                }

            });

            return text;
        }
        public Connection? Connection { get; set; }
        public string? DataBaseName { get; set; }

    }

    public class Connection
    {
        public string? Port { get; set; }
        public string? Server { get; set; }
        public string? User { get; set; }
        public string? DataBase { get; set; }
        public string? Password { get; set; }
    }

}
