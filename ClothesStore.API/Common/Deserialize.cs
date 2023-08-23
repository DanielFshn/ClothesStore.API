using Newtonsoft.Json;

namespace ClothesStore.API.Common;

public class Deserialize
{
    public static Dictionary<string,string> JsonDeserialize(string request)
    {
        return JsonConvert.DeserializeObject<Dictionary<string,string>>(request);
    }
}
