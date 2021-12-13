Readme:

The API has multiple layers:
* BaseLayer - responsible for the very fundamental classes for our API.


Future ToDos:

- Create a CacheManager to save the retrieved data and improving time performance.
- Use a lazy data laoder rather than eager. Not feeling well retrieving the whole database and working with it.
- pass context in a different wat, rather than within BL class contructors.
- Change the movie genres from classes to an enum and using some methods of mapping as in https://stackoverflow.com/questions/2290262/search-for-a-string-in-enum-and-return-the-enum. We don't want a separate db table for that
- Implement BO / DO layer to be async 
- Middleware securty and token authorisation
- Refactor the Base classes into interfaces