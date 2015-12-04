using System.Net.Http;
using System.Threading.Tasks;

namespace documentDB
{
    internal static class Authenticate
    {
        static HttpClient client = new HttpClient();

        internal static async Task<string> GetAuthorizationHeader(string httpRequest, string date, string docID)
        {
            string nodejsAuth = "http://nodejsauth.azurewebsites.net/documentDBAuth/{0}/{1}/{2}";
            switch (httpRequest)
            {
                case "get":
                    nodejsAuth = string.Format(nodejsAuth,"get", date, docID);
                    return await client.GetStringAsync(nodejsAuth);
                case "post":
                    nodejsAuth = string.Format(nodejsAuth,"post", date,docID);
                    return await client.GetStringAsync(nodejsAuth);
                case "put":
                    nodejsAuth = string.Format(nodejsAuth, "put", date, docID);
                    return await client.GetStringAsync(nodejsAuth);
                case "delete":
                    nodejsAuth = string.Format(nodejsAuth, "delete", date, docID);
                    return await client.GetStringAsync(nodejsAuth);
            }

            return null;
        }
    }
}
