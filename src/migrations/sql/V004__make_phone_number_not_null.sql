
-- Safety check
DO $$
BEGIN
    IF EXISTS (SELECT 1 FROM member WHERE phone_number IS NULL) THEN
        RAISE EXCEPTION 'Cannot enforce NOT NULL: some phone_number values are NULL';
END IF;
END $$;

ALTER TABLE member
    ALTER COLUMN phone_number SET NOT NULL;