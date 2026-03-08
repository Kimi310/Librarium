ALTER TABLE book
DROP COLUMN isbn;

ALTER TABLE book
    RENAME COLUMN isbn_text TO isbn;