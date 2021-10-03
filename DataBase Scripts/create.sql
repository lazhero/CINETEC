CREATE TABLE CLIENT(
    Id_card int ,
    Birthdate date,
    Phone_num int,
    First_name varchar(15),
    Middle_name varchar(15),
    Last_name varchar(15),
    Second_last_name varchar(15),
    Username varchar(15),
    Password varchar(15),
    PRIMARY KEY (Id_card, Username)
);
CREATE TABLE ROLE(
    Id smallserial,
    Name varchar(15),
    PRIMARY KEY (Id)
);
CREATE TABLE EMPLOYEE(
  Id_card int,
  Phone_num int,
  Birthdate date,
  Username varchar(15),
  Password varchar(15),
  First_name varchar(15),
  Middle_name varchar(15),
  Last_name varchar(15),
  Second_last_name varchar(15),
  First_date_working date,
  Cinema_name varchar(32),
  Role_id smallint,
  PRIMARY KEY(Id_card,Username)
);

CREATE TABLE CINEMA(
    Name varchar(32),
    Location varchar(31),
    Number_of_rooms smallint,
    PRIMARY KEY (Name)
);

CREATE TABLE ROOM(
    Cinema_name varchar(32),
    Rows smallint,
    Columns smallint,
    Number smallint,
    Capacity smallint,
    Restriction_percent int,
    PRIMARY KEY (Cinema_name,Number)
);

CREATE TABLE PROJECTION(
    Id serial,
    Date date,
    Initial_time time,
    End_time time,
    Movie_original_name varchar(31),
    PRIMARY KEY (Id)
);

CREATE TABLE INVOICE(
    Id serial,
    Description varchar(255),
    Ticket_number int,
    Total int,
    PRIMARY KEY (Id)
);

CREATE TABLE MOVIE(
    Original_name varchar(31),
    Name varchar(31),
    Image bytea,
    Time_length int,
    Kid_price int,
    Adult_price int,
    Elder_price int,
    PRIMARY KEY (Original_name)
);

CREATE TABLE CLASSIFICATION(
    Id serial,
    Description varchar(255),
    Initial smallint,
    Final smallint,
    PRIMARY KEY (Id)
);

CREATE TABLE ACTOR(
    First_name varchar(15),
    Middle_name varchar(15),
    Last_name varchar(15),
    Second_last_name varchar(15),
    Movie_name varchar(15),
    PRIMARY KEY (First_name,Middle_name,Last_name,Second_last_name)
);

CREATE TABLE DIRECTOR(
    First_name varchar(15),
    Middle_name varchar(15),
    Last_name varchar(15),
    Second_last_name varchar(15),
    Movie_name varchar(31),
    PRIMARY KEY (First_name,Middle_name,Last_name,Second_last_name)
);

CREATE TABLE PROJECTION_INVOICE(
    Projection_id int,
    Invoice_id int,
    PRIMARY KEY (Projection_id,Invoice_id)
);

CREATE TABLE CLIENT_INVOICE(
    Client_id int,
    Invoice_id int,
    Client_username varchar(15),
    PRIMARY KEY (Client_id,invoice_id,Client_username)
);

CREATE TABLE PROJECTION_ROOM(
    Projection_id int,
    Cinema_name varchar(32),
    Room_id smallint,
    PRIMARY KEY (Projection_id,Cinema_name,Room_id)
);

CREATE TABLE MOVIE_CLASSIFICATION(
    Movie_original_name varchar(31),
    Classification_id int,
    PRIMARY KEY (Movie_original_name,Classification_id)
);


CREATE TABLE PROJECTION_CLIENT(
    Projection_id int,
    Client_id_card int,
    Client_username varchar(15),
    PRIMARY KEY (Projection_id,Client_id_card,Client_username)
);

AlTER TABLE EMPLOYEE
ADD CONSTRAINT EMPLOYEE_CINEMA
FOREIGN KEY (Cinema_name) REFERENCES CINEMA(Name),
ADD CONSTRAINT  EMPLOYEE_ROLE
FOREIGN KEY (Role_id) REFERENCES ROLE(Id);


ALTER TABLE ROOM
ADD CONSTRAINT  ROOM_CINEMA
FOREIGN KEY (Cinema_name) REFERENCES CINEMA(Name);


ALTER TABLE PROJECTION
ADD CONSTRAINT  PROJECTION_MOVIE
FOREIGN KEY (Movie_original_name) REFERENCES  MOVIE(Original_name);

ALTER TABLE ACTOR
ADD CONSTRAINT ACTOR_MOVIE
FOREIGN KEY (Movie_name) REFERENCES  MOVIE(Original_name);



ALTER TABLE DIRECTOR
ADD CONSTRAINT DIRECTOR_MOVIE
FOREIGN KEY (Movie_name) REFERENCES  MOVIE(Original_name);


ALTER TABLE PROJECTION_INVOICE
ADD CONSTRAINT PI_PROJECTION
FOREIGN KEY (Projection_id) REFERENCES PROJECTION(Id),
ADD CONSTRAINT PI_INVOICE
FOREIGN KEY (Invoice_id) REFERENCES INVOICE(Id);

ALTER TABLE CLIENT_INVOICE
ADD CONSTRAINT CI_CLIENT
FOREIGN KEY (Client_id,Client_username) REFERENCES CLIENT(Id_card, Username),
ADD CONSTRAINT CI_INVOICE
FOREIGN KEY (invoice_id) REFERENCES INVOICE(Id);

ALTER TABLE PROJECTION_ROOM
ADD CONSTRAINT PR_PROJECTION
FOREIGN KEY (Projection_id) REFERENCES PROJECTION(Id),
ADD CONSTRAINT PR_ROOM_CINEMA
FOREIGN KEY (Cinema_name,Room_id) REFERENCES ROOM(Cinema_name,Number);

ALTER TABLE MOVIE_CLASSIFICATION
ADD CONSTRAINT MC_MOVIE
FOREIGN KEY (Movie_original_name) REFERENCES MOVIE(Original_name),
ADD CONSTRAINT MC_CLASSIFICATION
FOREIGN KEY (Classification_id) REFERENCES CLASSIFICATION(Id);

ALTER TABLE PROJECTION_CLIENT
ADD CONSTRAINT  PC_PROJECTION
FOREIGN KEY (projection_id) REFERENCES PROJECTION(Id),
ADD CONSTRAINT PC_CLIENT
FOREIGN KEY (Client_id_card,Client_username) REFERENCES CLIENT(Id_card,Username);