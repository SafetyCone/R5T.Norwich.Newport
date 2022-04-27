using System;
using System.Threading.Tasks;

using Newtonsoft.Json;

using R5T.Newport.Extensions;

using NewportUtilities = R5T.Newport.Utilities;using R5T.T0064;


namespace R5T.Norwich.Newport
{[ServiceImplementationMarker]
    public class NewtonsoftJsonFileSerializer : IJsonFileSerializer,IServiceImplementation
    {
        public async Task<T> DeserializeAsync<T>(string jsonFilePath)
        {
            var jsonSerializer = NewportUtilities.GetStandardJsonSerializer();

            var output = await Task.Run(() =>
            {
                var result = jsonSerializer.Deserialize<T>(jsonFilePath);
                return result;
            });

            return output;
        }

        public async Task SerializeAsync<T>(string jsonFilePath, T @object, bool overwrite = true)
        {
            var jsonSerializer = NewportUtilities.GetStandardJsonSerializer();

            await Task.Run(() =>
            {
                jsonSerializer.Serialize(jsonFilePath, @object, overwrite);
            });
        }
    }
}
