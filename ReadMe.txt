Hi there!
You've reached a documentDB wrapper for Windows UAP that also works for Xamarin :). 
Chances are you're here because:
- You need to use documentDB for Windows 10 but 'boo hoo' the SDK is not available for Win10 UAP
- You want to use documentDB for iOS / Android using Xamarin but then again 'boo hoo!', no SDK available
- You have used this project and would like to contribute to make it better
- You just want to have some laughs on clumsy code and poor judgement

I'm not going to include a section on what is documentDB as chances are you're here because you've read 
what it is and just need to use a decent wrapper or workaround for your project 
so let's jump to the methods of the classes that this wrapper has:

1. Authenticate
1.1 GetAuthorizationHeader method
- Internal async method
- Requires an HTTP verb (get, post, put, delete), a date and a documentID
- Returns a signed string that serves as the authenciation header in a HTTP request
- This method uses a nodeJS service hosted in Azure due to a non possible way to 
use HMAC encryption within the available Xamarin crypto libraries (If you have a better workaround please let me know :)!)

2. CRUD
2.1 Utilities
2.1.1 GetStringContent method
- Private method
- Requires a string that represents the body of the documentDB document
- Returns a StringContent containing what will serve as the body in an HTTP request to Azure documentDB

2.1.2 GetClient method
- Private async method
- Requires an HTTP verb (get, post, put, delete), the respective accountID and documentID from the account and document in documentDB
- This method prepares an HttpClient with the necessary headers to make an HTTP request to Azure (including the authorization header)

Up until this point, you won't actually interact with the methods described 
above as they are internal or private. You will only need to worry about
passing the right parameters to the methods described in the "CRUD methods" section below.

2.2 CRUD methods
2.2.1 createDocument method
- Public async method that creates a new document within a given collection
- Requires an accountID, databaseID, collectionID and a string that represents the json file that will be the body of the document to be created
- Returns a status code depending on the result of the request https://msdn.microsoft.com/en-us/library/azure/dn803948.aspx

2.2.2 getDocuments method
- Public async method that retrieves a json list of documents within a given collection
- Requires an accountID, databaseID and the collectionID string from the collection that contains the documents that have to be retrieved
- Returns a string that contains the documents, from a given collection, formated in a json File

2.2.3 getDocument method
- Public async method that retrieves a document within a given collection
- Requires an accountID, databaseID and collectionID strings
- Returns a string that contains the document, from a given documentID, formated in a json File

2.2.4 deleteDocument method
- Public async method that deletes a document given it's documentID
- Requires an accountID, databaseID, collectionID and the documentID of the document that will be deleted
- Returns a status code depending on the result of the request https://msdn.microsoft.com/en-us/library/azure/dn803952.aspx

2.2.5 updateDocument method
- Public async method that updates a document given its documentID and its new json body
- Requires an accountID, databaseID, collectionID, documentID and a string that represents the json file that will be the new body of the document
- Returns a status code depending on the result of the request https://msdn.microsoft.com/en-us/library/azure/dn803947.aspx


