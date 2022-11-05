[![Board Status](https://dev.azure.com/VGaraba/2f45c7ca-819f-477b-a388-bb430ce44a15/9807f194-35fc-4006-80d3-8d0d8af2c7d0/_apis/work/boardbadge/5ead1fc5-90ae-4808-80f3-a5d138921545)](https://dev.azure.com/VGaraba/2f45c7ca-819f-477b-a388-bb430ce44a15/_boards/board/t/9807f194-35fc-4006-80d3-8d0d8af2c7d0/Microsoft.RequirementCategory)

This is a representation of an API that is reading, writing and updating data for a movie collection.
Currently the data is stored in-memory using Entity Framework.

Currently, the API endpoints are:

* GET /api/A/{title}&{Rating}&{ReleaseYear}&{Genres} - returns a list of movies that satisfies the search criteria. Note that Genres is a list and can be inserted repeatedly.
* GET /api/B/ - returns the top 5 higest rated movies.
* GET /api/C/{username} - returns the top 5 highest rather movie for an user.
* POST/PUT /api/D/{Username}&{MovieTitle}&{Rating} - Adds or Updates a review for an user for a movie.

The API has multiple layers:
* BaseLayer - responsible for the very fundamental classes for our API.
* Entity Layer - the model classes.
* DataLayer - processes the data directly.
* Business Layer - All the processes that are not high level or are not touching the data directly from context.

Future ToDos:

- Create a CacheManager to save the retrieved data and improving time performance.
- Use a lazy data laoder rather than eager. Not feeling well retrieving the whole database and working with it.
- pass context in a different wat, rather than within BL class contructors.
- Change the movie genres from classes to an enum and using some methods of mapping as in https://stackoverflow.com/questions/2290262/search-for-a-string-in-enum-and-return-the-enum. We don't want a separate db table for that
- Implement BO / DO layer to be async 
- Middleware securty and token authorisation
- Refactor the Base classes into interfaces
- Create Test cases for API endpoints
- Average rating for movies should be done by the uncalculated value.
