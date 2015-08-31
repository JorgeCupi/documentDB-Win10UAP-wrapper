# documentDB-Win10UAP-wrapper
Simple Windows 10 UAP CRUD wrapper for documentDB services on Azure

I'm making this wrapper given that the official DocumentDB SDK for .NET is not ready for Windows 8.1 Universal Apps nor Windows 10 UAPs or is Cross plattform.

It is worth to notice that right now I'm authenticating the calls to documentDB using a NodeJS script hosted in an AzureWebApp (that until I find a local way to make the HMAC authentication to work cross plattform)
