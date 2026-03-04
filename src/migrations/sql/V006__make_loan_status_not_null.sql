UPDATE loan
SET status = 'Active'
WHERE status IS NULL;

ALTER TABLE loan
    ALTER COLUMN status SET NOT NULL;