SECTION 1
Section one is an implementation of OOP concepts inheritance and polymorphism.
I created a project named 'NetworkDevices' which contains a base or parent class (An abstract class) 'NetworkDevice'. In this class there are two properties, a constructor and an abstract method.
the properties have a private set method which privately sets the value of the properties via the constructor.
the abstract method is inherited by child classes and overriden to perfom the desired task
The three child classes include the Router, Switch and AccessPoint Classes which all have methodes that overrides and simulates the connect method. Each of these child classes have their own unique properties and inherits the properties
and method from the base class.

SECTION 2
Section two implements Docker and Kubernetes. 
I created an ASP.NET Core web application and wrote a Dockerfile to build and run the application. this process creates an image which is run in the docker container at runtime.
Additionally a Kubernetes manifest "deployment.yaml" was written which can be used to deploy the application in a Kubernetes cluster.

SECTION 3
In section three I implemented an application that interacts with both a SQL Server and a MongoDB database.
In my SQL Server I created a Product table with columns ProductID (int), ProductName(string), and Price(decimal). I then implemented a method to insert, update, delete, and retrieve all products from the database.
I created an applicationdbContext file with the following connection String "Server=DESKTOP-JOFBHPG; Database=Maliroso_Task3; Trusted_Connection=true; TrustServerCertificate=True;"
If you are to run this project, please remember to update the connection string according to the sql server available on your computer and exchange the connection string in the ApplicationDbContext file.
I also have a MongodbContext class/file which handles the connection with my local MongoDb
I defined the Product and Customer models in the Product and Customer classes respectively to enable working with the data.

I used a repository pattern in this design where I have repositories for the SqlServer Database and also for the MongoDb.
The SqldbRepository contains methods to add, get all products, update and delete product.
Also the MongoDbRepository contains methods to add, get all customer, update, and delete a customer.

in the Program.Main method, I created objects of the Sql ApplicationDbContext, the SqlRepository and MogoDbContext and the MongoDbRepository. 
this allowed me access to the various functions of the repository that allows me to add, get all products and customers from the respective databases.
My MongoDb uses a connection string "mongodb://localhost:27017", "Maliroso_task3". feel free to update this according to the available MongoDb instance on your computer.


SECTION 4
Section four is an implementation of a Peer-to-Peer (P2P) Network Simulation.
in this implementation each peer was designed to run on a seperate thread. and methods to send a message to all connected peers and to receive message was implemented.
I used Namespaces, System.Net.Sockets, and System.Threading. these namespaces gave me access to methods such as TcpListener, TcpClient and others important methods used in this task.

this implementation could be used to communicate between ports of the same computer by running multiple console windows with several instances of the application. 
When the application is run on the first peer, a port such as '5000' could be entered, on the second instance a different port number is entered to listen on "5001". the address of the first peer 
should then be entered to connect to it. example "172.20.176.1:5000". When the connection is successful, messaging could be sent and received between peers.

SECTION 5

Section five is an implementatioin of basic cryptography. here I implemented a simple encryption and decryption mechanism using AES in C#.
I created methodes to encrypt and decrypt a string using a symmetric key, and demonstrated the encryption and decryption of a sample string.
In this solution I used two main methods EncryptString and DecryptString Methods.

The EncryptString method generates a random IV using 'aesAlg.GenerateIV()' which is an object of the Aes class available in the System.Security.Cryptography namespace.
this method also prepares a 'MemoryStream' to hold the IV and encrypted data, writes the IV to the beginning of the MemoryStream, writes the encrypted data to the 'MemoryStream' and 
converts the combined IV and encrypted data to a base64 string.

The DecryptString method converts the base64 encoded string back to a byte array, then extracts the IV from the beginning of the byte array, extracts the ciphertext from the remainder of the byte
array, sets the IV for the AES algorithm and then Decrypts the ciphertext using the extracted IV.


SECTION 6
Section six is the implementation of an IoT device that sends temperature data to a server. The IoT device generates random temperature readings every 5 seconds and sends theem to a server endpoint.
The Server receives and stores the temperature data.

In this section I designed two applications. the first one is the TemperatureServer which is a ASP.NET Core Web API. in this API project, I implemented Entity Framework Code First migration where I created the 
'ApiDbContext' which contains a DbSet of the Temperature Class. The Temperature class is the model of the temperature that will be stored in the database which consist of properties such as the Id, the temperature
value and the timestamp when the temperature was sent.
A service was added in the program.cs file to enable the use of SqlServer and before this the necessary packages such as Microsoft.EntityFrameworkCore.SqlServer and Microsoft.EntityFrameworkCore.Design
were installed. the connection string 'Server=DESKTOP-JOFBHPG; Database=Maliroso_Task6Db; Trusted_Connection=true; TrustServerCertificate=True;' was added in the appsettings.json file

A post endpoint is designed in the Temperature controller which recieves a temperature model and then saves the teperature in the database.

In the second part of this implementation a Console Application was used to server as the IoT Device Simulator. in this application I used the System.Net.Http and the HttpClient class to send temperature data
to the ServerUrl "https://localhost:7010/api/temperature" which is the API endpoint from the first part of this section. Random temperature between -10 and 40 is generated through the help of methods using the Math.Round class and method
The generated temperature is sent to the ServerUrl and this is saved by the API endpoint into the database.

for this implementation, both the API project (TemperatureServer) and the Console project (IoTDevice) must be running together on the machine to be able to get the desired results.
the image below shows a screenshot of the testing.

![image](https://github.com/user-attachments/assets/cf5dbf24-bb48-4d64-b372-72c0c32c6040)
![image](https://github.com/user-attachments/assets/37c3242c-92b8-42e7-b1ff-8765c1d21463)






