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

****
**Second requirement**

Step 1 

Migration file: V003__enforce_unique_email_and_add_phone_nullable.sql

Description: Email uniqueness enforced. Existing duplicates were resolved by appending member ID to ensure determinism.
Phone number introduced but remains optional.
Must be applied before new API is deployed. Old API continues functioning since phone_number is nullable.
I chose to automatically resolve duplicate
emails rather than aborting migration. This avoids 
manual intervention but modifies existing data 
deterministically. Phone number was added as 
nullable to avoid breaking running application 
during deployment window.

Step 2

Migration file: V004__make_phone_number_not_null.sql

Description: phone_number becomes mandatory.
Must be applied only after all members have phone numbers 
populated.

Decision & tradeoffs:
We separated this into a second migration to avoid 
breaking the live application during rollout. This follows 
a safe expand-and-contract migration pattern.

****

**Third requirement**

Step 1
Migration file:
V005__add_loan_status_nullable_and_backfill.sql

Description:
A new status column was added to the loan table to support 
the extended loan lifecycle: Active, Returned, Overdue, and Lost.
Existing rows were backfilled based on current data:

Loans with return_date IS NOT NULL → Returned

Loans with return_date IS NULL → Active

The column was introduced as nullable to avoid
breaking the currently deployed API, which does not yet set
status.

Decision & tradeoffs:
The column was added as nullable to avoid runtime failures 
during the deployment window. The existing "frontend" determines 
loan state based on returnDate, so I preserved this 
logic. Filling exisiting data ensures that the data remains consistent 
with the new status model. This allows the backend to gradually
transition to status based 
state management without disrupting the frontend integration.

Step 2
Migration file:
V006__make_loan_status_not_null.sql

Description:
The status column becomes mandatory (NOT NULL) after 
the application has been updated to always set a status 
when creating or updating loans. The dto for new loan got changed 
to support status regognistion.

Decision & tradeoffs:
This migration was separated to avoid breaking the 
existing application before it is updated to write the
new field. By delaying enforcement of the NOT NULL 
constraint, we ensure backward compatibility during the 
transition period. This again follows the expand-and-contract 
pattern and enables safe evolution of the domain model without 
impacting active consumers of the API.


Migration file:
V007__add_book_retired_flag.sql

Description:
A new is_retired column was added to the book table with 
default false. This allows books to be retired from 
circulation without being physically deleted. Loan history 
and foreign key relationships remain intact.

Decision & tradeoffs:
The original proposal suggested using an IsDeleted 
flag with manual query filtering. We accepted the soft-state 
concept but renamed the column to is_retired. Instead of 
relying on manual filtering, a global query filter was
introduced in AppDbContext to ensure consistent behavior 
across all queries. Additional validation was added to 
prevent new loans for retired books. 
