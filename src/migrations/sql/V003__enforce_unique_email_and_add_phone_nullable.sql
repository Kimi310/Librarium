--handling email duplicates

WITH duplicates AS (
    SELECT id,
           email,
           ROW_NUMBER() OVER (PARTITION BY email ORDER BY id) AS rn
    FROM member
)

UPDATE member m
SET email = m.email || '.' || m.id
    FROM duplicates d
WHERE m.id = d.id
  AND d.rn > 1;

ALTER TABLE member
    ADD COLUMN phone_number VARCHAR(30);

ALTER TABLE member
    ADD CONSTRAINT member_email_unique UNIQUE (email);