# netflix-watchlist-service

**Overview**

The goal of this service is to create a API to allow users to track the TV shows they have watched. 

**Requirements**

1) Register new User
2) Login
3) Show the list of available shows in the dashboard (two groups => user shows, all other shows)
	3.1) Group1=> If the user watched any show/episode, then show it in the watching list	
	3.2) Group2=> Show the remaining show next group
	3.3) if the user click on any available show and get the episode details
4) Add/Remove Show
	4.1) Make an search on show name from OMDB API and add it into system
			Make sure that will get added into Group2
			Note: (Integrated with IMDB to pull details of the show, 
				available episodes, make search easier for adding a show or add icons for the shows)
	4.2) Make sure to provide options to delete
5) Enable user to set the episode is watched
6) Show the user how many show that he watched and how many episode he is completed


**API Endpoint details**

Technology used: **.Net core 3.1 WebApi, EFCore, Automapper, InMemorycache, IMDbApi package & SQL-Server**

1) User
	Register - Register new user to the system
	Login - Validate the login of individual user
	Logout - Logout the existing user
2) Show Dashboard
	ListOfWatched-Shows For Login-User - display the watched show of logged user
	ListOfShows - Display all the shows available in the system
	GetEpisodesByShow - When the user click on the show, he shoud get all the episodes
	SetEpisodeWatchedByUser(showId, episodeId) - Marking the episode as watched, this action is done by user
	Search shows (Integration with IMDB API) - Add Integration of IMDB API to the current system. Also allow user to search the shows and get it added into the system
		Add the show to system
		Remove the show to system
3) Show the user on the watched show and its episode details - Show the watched list of shows to the logged user
