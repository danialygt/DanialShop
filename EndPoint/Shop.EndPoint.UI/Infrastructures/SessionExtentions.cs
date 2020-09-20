using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Shop.EndPoints.WebUI.Infrastructures
{
    public static class SessionExtentions
    {

        public static void SetJson(this ISession session, string key, object value)
        {
            
            // inja error darim ke mige value miofte to loop 
            // bekhatere inke dto tarif nakardm va hamaro az entity ha estefade kardm :|
            session.SetString(key, JsonConvert.SerializeObject(value));
        }


        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }

    }
}
