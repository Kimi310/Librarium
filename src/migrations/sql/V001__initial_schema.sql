-- V001__initial_schema.sql
-- Initial schema for Librarium
-- Creates Book, Member, and Loan tables

CREATE TABLE book (
                      id BIGSERIAL PRIMARY KEY,
                      title VARCHAR(300) NOT NULL,
                      isbn VARCHAR(20) NOT NULL UNIQUE,
                      publication_year INTEGER NOT NULL
);

CREATE TABLE member (
                        id BIGSERIAL PRIMARY KEY,
                        first_name VARCHAR(100) NOT NULL,
                        last_name VARCHAR(100) NOT NULL,
                        email VARCHAR(255) NOT NULL
);

CREATE TABLE loan (
                      id BIGSERIAL PRIMARY KEY,
                      book_id BIGINT NOT NULL,
                      member_id BIGINT NOT NULL,
                      loan_date DATE NOT NULL,
                      return_date DATE NULL,

                      CONSTRAINT fk_loan_book
                          FOREIGN KEY (book_id)
                              REFERENCES book(id)
                              ON DELETE RESTRICT,

                      CONSTRAINT fk_loan_member
                          FOREIGN KEY (member_id)
                              REFERENCES member(id)
                              ON DELETE RESTRICT
);