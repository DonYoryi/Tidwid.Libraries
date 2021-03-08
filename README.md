# Tidwid.Libraries
# Prerequisites

 ### Backend
 
1. Visual Studio 2017
2. .Net core 3.1

 ### Frontend

1. Nodejs 14.5 

 ### data base

1. sqlserver 2018 

# Install & Run
 
 ### Backend

1. Open Visual Studio 2017 and open Tidwid.Libraries.sln
2. Run the Proyect Tidwid.Libraries.Api 

 ### Frontend

1. Go to Tidwid.Libraries.UI/Libraries
2. Install depedencies
		
        npm install

3. Run
    
        npm start

 ### data base

1. Go to Tidwit.Libraries.Infra.DataAccess\Scripts
2. execute sql scripst
3. Go to Tidwid.Libraries.Api and replace connection string in appsetings
		

# Solution Architecture

## Backend

- Based on Onion Arquitecture and best practice of clean code

![alt text](https://tech.ovoenergy.com/content/images/2018/12/OnionLayersLabelled-2.png)


 ## Frontend

- MVVM Patterm
- https://angular.io/guide/styleguide
