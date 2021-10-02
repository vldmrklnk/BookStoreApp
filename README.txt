Primary requirements

The server application must run over HTTP REST and use .NET Core 3.0. 
A server application is a Windows service or a regular Windows application that provides an HTTP API for a client application. 
The client side must be a Windows application using the WPF .NET Framework 4.7 graphical interface technology.

Additional requirements

Server part
- loading information cards from a file on the server side. Choice of file format - JSON, XML
- saving added and changed information cards to a file on the server side
- handling user GUI requests for CRUD operations with info cards
- error handling when working with a client

Client part

- displaying a list of information cards in the GUI of the client application with displaying graphic images for each information card
- support for CRUD operations for information cards
- error handling when working with the server
- graphic images can be in JPG, PNG format. Support for one of the formats is enough
- sorting information cards by name (optional)
- the ability to delete several information cards in one operation (optional function)
- error checking of information card input - empty title and missing image (optional function)