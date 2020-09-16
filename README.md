# Group_API_Project --Liquor Barn--
![Cocktail](https://user-images.githubusercontent.com/63912277/93373892-f9fef180-f823-11ea-972e-a39862361537.PNG)
  
### The app for Fancy Cocktail Creators! The Liquor Barn will store cocktail recipes, present a list of cocktails that contain a particular spirit, and create new and unique cocktails.
好きなお酒からお好みのカクテルレシピを作れるこのアプリを活用して、アルコールと良い関係を築きましょう。
التطبيق الالكتروني الذي يخزن و يحفظ المشوبات المسكرة التي المستخدمين ممكن يريدون أن يشربوها


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
    - Update and delete the data above  


## App Endpoints

###  Account:
  
        POST: /api/Account/Register        => Registers new user account

###  Liquor: 
  
        POST: /api/Liquor              => Inputs new liquor data to DB
        GET:  /api/Liquor              => Gets all liquor info
        GET:  /api/Liquor/{id}         => Gets all liquor info associated with its ID
        PUT:  /api/Liquor/{id}         => Updates a specific liquor item in the DB by ID
        DELETE: /api/Liquor/{id}       => Deletes a specific liquor item in the DB by ID

###  Cocktail: 
  
        POST: /api/Cocktail               => Allows a user to post a new cocktail with ingredients and data-stored liquor info
        GET:  /api/Cocktail               => Shows all the cocktail recipes on DB
        GET:  /api/Cocktail/{id}          => Pulls specific cocktail recipe to view by ID
        GET:  /api/Cocktail/ByName/{name} => Pulls specific cocktail recipe to view by its Name
        PUT:  /api/Cocktail/{id}          => Allows the user to update/fix a cocktail recipe that was stored in the DB
        DELETE: /api/Cocktail/{id}        => Allows the user to delete a cocktail recipe that is on the DB
        
###  CustomCocktail: 
  
        POST: /api/CustomCocktail               => Allows a user to post a new custom cocktail with ingredients and data-stored liquor info
        GET:  /api/CustomCocktail               => Shows all the custom cocktail recipes on DB
        GET:  /api/CustomCocktail/{id}          => Pulls specific cocktail recipe to view by ID
        GET:  /api/CustomCocktail/ByName/{name} => Pulls specific cocktail recipe(s) to view by its Name
        PUT:  /api/CustomCocktail/{id}          => Allows the user to update/fix a cocktail recipe that was stored in the DB
        DELETE:/api/CustomCocktail/{id}         => Allows the user to delete a cocktail recipe that is on the DB
        
### SpecificLiquor
	
        POST: /api/SpecificLiquor              => Creates an SL
        GET:  /api/SpecificLiquor/ByBrand      => Calls a list of specific liquors filtering by brand
        GET:  /api/SpecificLiquor/ByCountry    => Calls a list of SLs by filtering by country 
        GET:  /api/SpecificLiquor              => Calls a list of all SLs
        GET:  /api/SpecificLiquor/{id}         => Calls one SL by its individual ID via the URI
        PUT:  /api/SpecificLiquor/{id}         => Edits one SL targeting its ID and new content from body
        DELETE: /api/SpecificLiquor/{id}       => Deletes one SL
	
###  Preference: 
  
        POST:   /api/Preference/{id}    => Save a cocktail to user's preference list
        GET:    /api/Preference         => Gets preference list
        DELETE: /api/Preference/{id}    => Remove a cocktail from user's preference list
        DELETE: /api/Preference         => Clear user's preference list

## Resource Link
	https://stackoverflow.com/questions/10007351/entity-framework-code-first-addorupdate-method-insert-duplicate-values
	https://stackoverflow.com/questions/13376720/how-can-an-object-property-be-aware-of-its-parent-item
	https://www.techopedia.com/definition/7272/foreign-key
	https://entityframework.net/knowledge-base/44747032/no-context-type-was-found-in-the-assembly-when-running-code-first-migration
	https://www.youtube.com/watch?v=GblxFZpR10w
	https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=netcore-3.1





