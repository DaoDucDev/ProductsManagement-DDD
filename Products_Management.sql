CREATE DATABASE products_management;


drop  table  products;
CREATE TABLE products(
    product_id uuid NOT NULL ,
    product_name varchar NOT NULL ,
    quantity int NOT NULL ,
    price double precision NOT NULL,
    PRIMARY KEY (product_id)
);

SELECT * FROM products;

