#!/bin/bash

# Base URL of the API
BASE_URL="https://localhost:7103/Harbours"

# Example data for POST and PUT requests
CREATE_HARBOUR_JSON='{
  "name": "Example Harbour",
  "street": "123 Example Street",
  "city": "Example City",
  "country": "Example Country"
}'

UPDATE_HARBOUR_JSON='{
  "id": "example-guid", # Replace with a valid GUID
  "name": "Updated Harbour",
  "street": "456 Updated Street",
  "city": "Updated City",
  "country": "Updated Country"
}'

# GET all harbours
echo "GET all harbours:"
curl -X GET "$BASE_URL" -H "accept: application/json"
echo -e "\n"

# GET a single harbour by ID (replace {id} with a valid GUID)
echo "GET single harbour by ID:"
curl -X GET "$BASE_URL/{id}" -H "accept: application/json"
echo -e "\n"

# POST a new harbour
echo "POST new harbour:"
curl -X POST "$BASE_URL" -H "Content-Type: application/json" -d "$CREATE_HARBOUR_JSON"
echo -e "\n"

# PUT to update a harbour (replace {id} with a valid GUID)
echo "PUT update harbour:"
curl -X PUT "$BASE_URL/{id}" -H "Content-Type: application/json" -d "$UPDATE_HARBOUR_JSON"
echo -e "\n"

# DELETE a harbour by ID (replace {id} with a valid GUID)
echo "DELETE harbour by ID:"
curl -X DELETE "$BASE_URL/{id}"
echo -e "\n"