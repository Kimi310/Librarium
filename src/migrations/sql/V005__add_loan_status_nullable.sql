ALTER TABLE loan
    ADD COLUMN status VARCHAR(20);

-- Returned loans
UPDATE loan
SET status = 'Returned'
WHERE return_date IS NOT NULL;

-- Active loans
UPDATE loan
SET status = 'Active'
WHERE return_date IS NULL;

ALTER TABLE loan
    ADD CONSTRAINT loan_status_check
        CHECK (status IN ('Active', 'Returned', 'Overdue', 'Lost'));