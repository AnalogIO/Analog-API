# Analog API & Website
This is the API for fetching opening hours and shifts in Café Analog at the IT University of Copenhagen.

## Description
The API communicates with the current shift planning management tool at the café, and serves this data as JSON. 

The website fetches shift data and displays the opening hours and people currently on shift.

## API Examples
#### Routes
- ```/api/shifts``` Get shifts a week ahead. 
- ```/api/open``` Get data of whether the café is open currently
- ```/api/shifts/today``` Get today's shifts
- ```/api/shifts/day/dd-MM-yyyy``` Get shifts on a specific day
