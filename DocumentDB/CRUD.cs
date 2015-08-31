using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IoTChallenge.Universal.Core
{
    public static partial class documentDB
    {
        public static async Task<string> createDocument(string accountID, string dbID, string collectionID, string jsonFile)
        {
            string url = "https://{0}.documents.azure.com/dbs/{1}/colls/{2}/docs";
            url = String.Format(url, accountID, dbID, collectionID);

            StringContent body = GetStringContent(jsonFile);
            HttpClient client = await GetClient("post", accountID, collectionID);

            try
            {
                HttpResponseMessage result = await client.PostAsync(url, body);
                return result.StatusCode.ToString() + " Documento creado";
            }
            catch (Exception ex) { return ex.Message; }
        }
        public static async Task<string> getDocuments(string accountID, string dbID, string collectionID)
        {
            string url = "https://{0}.documents.azure.com/dbs/{1}/colls/{2}/docs";
            url = String.Format(url, accountID, dbID, collectionID);
            HttpClient client = await GetClient("get", accountID, collectionID);

            try
            {
                string result = await client.GetStringAsync(url);
                return result;
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static async Task<string> getDocument(string accountID, string dbID, string collectionID, string documentID)
        {
            string url = "https://{0}.documents.azure.com/dbs/{1}/colls/{2}/docs/{3}";
            url = String.Format(url, accountID, dbID, collectionID,documentID);
            HttpClient client = await GetClient("get", accountID, documentID);

            try
            {
                string result = await client.GetStringAsync(url);
                return result;
            }
            catch (Exception ex) {return ex.Message;}
        }

        public static async Task<string> deleteDocument(string accountID, string dbID, string collectionID, string documentID)
        {
            string url = "https://{0}.documents.azure.com/dbs/{1}/colls/{2}/docs/{3}";
            url = String.Format(url, accountID, dbID, collectionID, documentID);
            HttpClient client = await GetClient("delete", accountID, documentID);

            try
            {
                HttpResponseMessage result = await client.DeleteAsync(url);
                return result.StatusCode.ToString() + " Documento eliminado";
            }
            catch (Exception ex) { return ex.Message; }
        }

        public static async Task<string> updateDocument(string accountID, string dbID, string collectionID, string documentID, string jsonFile)
        {
            string url = "https://{0}.documents.azure.com/dbs/{1}/colls/{2}/docs/{3}";
            url = String.Format(url, accountID, dbID, collectionID, documentID);

            StringContent body = GetStringContent(jsonFile);
            HttpClient client = await GetClient("put", accountID, documentID);

            try
            {
                HttpResponseMessage result = await client.PutAsync(url, body);
                return result.StatusCode.ToString() + " Documento actualizado";
            }
            catch (Exception ex) { return ex.Message; }
        }
    }
}
