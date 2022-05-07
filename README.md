# Async-Inn
 API server for a Hotel Asset Management system 

 Author: Sultan Kanaan

 Lab 11: Databases and ERDs _ 14-4-2022

 Lab 12: Intro to Entity Framework _ 19-4-2022

 Lab 13: Dependency Injection _ 20-4-2022
 
 Lab 14: Navigation Properties & Routing _ 24-4-2022
 
 Lab 16: Data Transfer Objects (DTOs) _ 27-4-2022

 Lab 18: Identity _3-5-2022





---

## Identity :
ASP.NET Core Identity was created to help with the security and management of users. It provides this abstraction layer between the application and the users/role data. We can use the API in it’s entirety, or just bits and pieces as we need (such as the salting/hashing by itself) or email services. There is a lot of flexibility within ASP.NET Core Identity. We have the ability to take or leave whatever we want. Identity combines well with EFCore and SQL Server.


## Register User :

![](./assets/Regester.png)

## Login Users :

![](./assets/Login.png)


## architecture :

* in This projetct i have 3 model (Hotels, Rooms, and Amenities).
* and also i have 3 interface for evry model.
* service for each of the controllers that implement the appropriate interface.
* CRUD operations for evry class.
* I Update the Controller to use the appropriate method from the interface rather than the DBContext directly.

---
 # API Routes

## Users :

![](./assets/Users.png)
 
## Hotel Routes :

![](./assets/Hotels.png).


## Rooms Routes :

![](./assets/Rooms.png)

## HotelRoom Routes :

![](./assets/HotelRooms.png)

## Amenities Routes :

![](./assets/Amenities.png)

## Room Amenities Routes:

![](./assets/RoomAmenities.png)


## Tables 

![](./assets/Data.png)

---

## API

![](./assets/SW.png)

![](./assets/API.png)

![](./assets/APIRooms.png)

![](./assets/APIAMnetis.png)

![](./assets/Gethotelbyid.png)

![](./assets/CreateHotel.png)


