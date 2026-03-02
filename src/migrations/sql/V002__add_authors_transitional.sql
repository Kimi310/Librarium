
CREATE TABLE author (
                        id BIGSERIAL PRIMARY KEY,
                        first_name VARCHAR(100) NOT NULL,
                        last_name VARCHAR(100) NOT NULL,
                        biography TEXT NULL
);

CREATE TABLE book_author (
                             book_id BIGINT NOT NULL,
                             author_id BIGINT NOT NULL,

                             PRIMARY KEY (book_id, author_id),

                             CONSTRAINT fk_book_author_book
                                 FOREIGN KEY (book_id)
                                     REFERENCES book(id)
                                     ON DELETE CASCADE,

                             CONSTRAINT fk_book_author_author
                                 FOREIGN KEY (author_id)
                                     REFERENCES author(id)
                                     ON DELETE CASCADE
);
