# HBA(Homerun Backend Assesment)

This project contains two different API. RatingService.Api and NotificationService.Api. API's don't know each other. Rating Service publishes the new rates. Notification Service consumes the queues. You can check the code for Unit testing, Error handling, General structure etc. 

##### Since there are little time left for NotificationService.Api I didn't write Unit Test for this API.  I am sorry for that :/

### You can contact with me via email: bahadir.cengel@gmail.com
## Running the application
There are docker-compose file inside solution. All you have to do is docker-compose up :) 
# RatingService.Api
This API is based on an N-Tier architecture. It has 2 endpoints. These endpoints are Rate, Avarage. 
## NOTE: When a new rating has been posted, it also sends it to the queue of the provider. 

## General restrictions
To be able to use these endpoints. You can use the users and providers that I seeded. 
#### For request/response examples you can use API's swagger page.(http://localhost:5050/swagger/index.html)

### Users
#### Id = 1, Name = "Abuzer", Surname = "Kadayif"
#### Id = 2, Name = "Temel", Surname = "Reis"
### Providers
#### Id = 1, Name = "Ilyas", Surname = "Salman"
#### Id = 2, Name = "Adile", Surname = "Nasit"

### Rating endpoint
Two users and two providers have been added. As a simple business logic for rating a provider, both the user and provider must exist in the DB.
And you must give your rate between 0 and 5. 

### Average Rate endpoint
To be able to see the average point of a provider. That provider must be on DB.

# NotificationService.Api
It only receives the NotifyProvider results via simple AMQP. It consumes the provider's queue. Has a sloppy error handling :/
#### You can check this API from (http://localhost:5000/swagger/index.html)

