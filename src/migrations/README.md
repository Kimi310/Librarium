**Initial state**

Migration file: V001__initial_schema.sql

Description: Contains initial schema for the database described in the introduction part of the assignment.

****

**First requirement**

Migration file: V002__add_authors_transitional.sql

Description: Transitional (additive) migration. Existing books are allowed to have zero authors. 
Application layer will enforce at least one author for new books.
The second option that I was considering is injecting mock data
for exisiting books like "Unknown author", but the method I decided 
to go with doesn't require to add additional fabricated data.
The response data of the controller has been changed to a dto instead that could influent a small downtime on some of the frontend 
capabilities however the dto is very similar to the original class so the downtime would be minimal. This downtime in my opinion would be better than 
maintaining two versions of an endpoint.