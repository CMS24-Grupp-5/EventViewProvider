EVENTVIEWPROVIDER

Azure URL: https://eventviewprovider.azurewebsites.net/api/events

EventViewProvider är en backend-microservice som fungerar som mellanhand mellan EventProvider och frontend. 
Den hämtar evenemang från en annan microservice (EventProvider), bearbetar dem och skickar vidare till frontend. 

Funktioner:

Filtrera på: 
* title
* location
* startDate och endDate (datumintervall)

Sortera: sort=true, order=asc eller desc

Visar endast aktuella events som standard. Justera startDate/endDate i filtret för att se äldre evenemang.

<img width="959" alt="Frontend - Upcoming Events" src="https://github.com/user-attachments/assets/09909467-4a31-4502-902f-f393b777732e" />

<img width="951" alt="Frontend - Visar gammalt event" src="https://github.com/user-attachments/assets/fa5c0d56-84d3-4930-83c7-633ebe03236d" />


