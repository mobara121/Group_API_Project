# Group_API_Project --Liquor Barn--
![Cocktail](https://user-images.githubusercontent.com/63912277/93373892-f9fef180-f823-11ea-972e-a39862361537.PNG)
  
### The app for Fnacy Cocktail Creaters! The Liquor Barn will store cocktail recipes, present a list of cocktails that contain a particular spirit, and create new and unique cocktails.
好きなお酒からお好みのカクテルレシピを作れるこのアプリを活用して、アルコールと良い関係を築きましょう。


## Created by Another Team 2:
  - Gabriel -- github.com/gabalv
  - Matthew -- github.com/mjvanscoik
  - Mizue -- github.com/mobara121
  
  
## App Features
  
###  Users:
    - Register account
    - Store liquor type, and subtype if necessary
    - Store Cocktail with stored liqour data  
    - Create custom cocktail with favorite ingredients
    - Search stored cocktail recipies
    - Update and delete the datas above
    
###  Admins:
    - Create, update or delete Daily Lotto users and lottery locations   


## App Endpoints

###  Account:
  
        POST: /api/Account/Regiser        => Registers new user account

###  Liquor: 
  
        POST: /api/Liquor              => Inputs new liquor data to DB
        GET:  /api/Liqour              => Gets all liquor info
        GET:  /api/Liquor/{id}         => Gets all liquor info associated with its ID
        PUT:  /api/Liquor/{id}         => Updates a specific liquor item in the DB by ID
        DELETE: /api/Liqour/{id}       => Deletes a specific liquor item in the DB by ID

###  Cocktail: 
  
        POST: /api/Cocktail            => Allows a user to post a new cocktail with ingredients and data-stored liquor info
        GET:  /api/Cocktail            => Shows all the cocktail recipes on DB
        GET:  /api/Cocktail/{id}       => Pulls specific cocktail recipe(s) to view by ID
        PUT:  /api/Cocktail/{id}       => Allows the user to update/fix a cocktail recipe that was stored in the DB
        DELETE: /api/Cocktail/{id}     => Allows the user to delete a cocktail recipe that is on the DB
        
###  CustomCocktail: 
  
        POST: /api/CustomCocktail               => Allows a user to post a new custom cocktail with ingredients and data-stored liquor info
        GET:  /api/CustomCocktail               => Shows all the custom cocktail recipes on DB
        GET:  /api/CustomCocktail/{id}          => Pulls specific cocktail recipe(s) to view by ID
        GET:  /api/CustomCocktail/ByName/{name} => Pulls specific cocktail recipe(s) to view by its Name
        PUT:  /api/CustomCocktail/{id}          => Allows the user to update/fix a cocktail recipe that was stored in the DB
        DELETE:/api/CustomCocktail/{id}         => Allows the user to delete a cocktail recipe that is on the DB
        
### SpecificLiquor
	
        GET: /api/SpecificLiquor/ByBrand      =>  Calls a list of specific liquors filtering by brand
	      GET: /api/SpecificLiquor/ByCountry    => Calls a list of SL’s by filtering by country
	      POST: /api/SpecificLiquor             => Creates an SL 
	      GET: /api/SpecificLiquor              => Calls a list of all SL’s
	      GET: /api/SpecificLiquor/{id}         => Calls one SL by its individual ID via the URI
	      PUT: /api/SpecificLiquor/{id}         => Edits one SL targeting its ID and new content form body
	DELETE: /api/SpecificLiquor/{id}  => Deletes one SL