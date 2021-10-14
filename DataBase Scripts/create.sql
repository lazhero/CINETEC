CREATE TABLE CLIENT(
    Id_card int UNIQUE ,
    Birthdate date,
    Phone_num int,
    First_name varchar(15),
    Middle_name varchar(15),
    Last_name varchar(15),
    Second_last_name varchar(15),
    Username varchar(15) UNIQUE,
    Password varchar(15),
    PRIMARY KEY (Id_card, Username)
);
CREATE TABLE ROLE(
    Id serial,
    Name varchar(30),
    PRIMARY KEY (Id)
);
CREATE TABLE EMPLOYEE(
  Id_card int UNIQUE,
  Phone_num int,
  Birthdate date,
  Username varchar(15) UNIQUE,
  Password varchar(15),
  First_name varchar(15),
  Middle_name varchar(15),
  Last_name varchar(15),
  Second_last_name varchar(15),
  First_date_working date,
  Cinema_name varchar(32),
  Role_id int,
  PRIMARY KEY(Id_card,Username)
);

CREATE TABLE CINEMA(
    Name varchar(32),
    Location varchar(31),
    PRIMARY KEY (Name)
);

CREATE TABLE ROOM(
    Cinema_name varchar(32),
    Rows smallint,
    Columns smallint,
    Number smallint,
    Restriction_percent int,
    PRIMARY KEY (Cinema_name,Number)
);

CREATE TABLE PROJECTION(
    Id serial,
    Date date,
    Initial_time time,
    End_time time,
    Movie_original_name varchar(31),
    Room_number smallint,
    Cinema_name varchar(32),
    PRIMARY KEY (Id)
);

CREATE TABLE INVOICE(
    Id serial,
    Description varchar(255),
    Num_elder_ticket int,
    Num_kid_ticket int,
    Num_adult_ticket int,
    PRIMARY KEY (Id)
);

CREATE TABLE MOVIE(
    Original_name varchar(31),
    Name varchar(31),
    Image varchar(260),
    Time_length int,
    Kid_price int,
    Adult_price int,
    Elder_price int,
    Director_First_name varchar(15),
    Director_Middle_name varchar(15),
    Director_Last_name varchar(15),
    Director_Second_last_name varchar(15),
    PRIMARY KEY (Original_name)
);

CREATE TABLE CLASSIFICATION(
    Id varchar(6),
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
    PRIMARY KEY (First_name,Middle_name,Last_name,Second_last_name)
);

CREATE TABLE DIRECTOR(
    First_name varchar(15),
    Middle_name varchar(15),
    Last_name varchar(15),
    Second_last_name varchar(15),
    PRIMARY KEY (First_name,Middle_name,Last_name,Second_last_name)
);

CREATE TABLE SEAT(
    Projection_id int,
    Seat_Number smallint,
    State smallint,
    Invoice_id int,
    PRIMARY KEY (Projection_id,Seat_Number)
);

CREATE TABLE CLIENT_INVOICE(
    Client_id int,
    Invoice_id int,
    Client_username varchar(15),
    PRIMARY KEY (Client_id,invoice_id,Client_username)
);


CREATE TABLE MOVIE_CLASSIFICATION(
    Movie_original_name varchar(31),
    Classification_id varchar(6),
    PRIMARY KEY (Movie_original_name,Classification_id)
);

CREATE TABLE ACTOR_MOVIE(
    Actor_first_name varchar(15),
    Actor_middle_name varchar(15),
    Actor_Last_name varchar(15),
    Actor_second_last_name varchar(15),
    Movie_Original_name varchar(31),
    PRIMARY KEY (Actor_first_name,Actor_middle_name,Actor_Last_name,Actor_second_last_name,Movie_Original_name)

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
FOREIGN KEY (Movie_original_name) REFERENCES  MOVIE(Original_name),
ADD CONSTRAINT  PROJECTION_ROOM
FOREIGN KEY (Room_number,Cinema_name) REFERENCES  ROOM(Number,Cinema_name);


ALTER TABLE MOVIE
ADD CONSTRAINT MOVIE_DIRECTOR
FOREIGN KEY (Director_First_name,Director_Middle_name,Director_Last_name,Director_Second_last_name) REFERENCES  DIRECTOR(First_name, Middle_name, Last_name, Second_last_name) ;

ALTER TABLE SEAT
ADD CONSTRAINT SEAT_PROJECTION
FOREIGN KEY (Projection_id) REFERENCES PROJECTION(Id),
ADD CONSTRAINT SEAT_INVOICE
FOREIGN KEY (Invoice_id) REFERENCES INVOICE(Id);

ALTER TABLE CLIENT_INVOICE
ADD CONSTRAINT CI_CLIENT
FOREIGN KEY (Client_id,Client_username) REFERENCES CLIENT(Id_card, Username),
ADD CONSTRAINT CI_INVOICE
FOREIGN KEY (invoice_id) REFERENCES INVOICE(Id);

ALTER TABLE MOVIE_CLASSIFICATION
ADD CONSTRAINT MC_MOVIE
FOREIGN KEY (Movie_original_name) REFERENCES MOVIE(Original_name),
ADD CONSTRAINT MC_CLASSIFICATION
FOREIGN KEY (Classification_id) REFERENCES CLASSIFICATION(Id);

ALTER TABLE ACTOR_MOVIE
ADD CONSTRAINT AM_ACTOR
FOREIGN KEY (Actor_first_name,Actor_middle_name,Actor_Last_name,Actor_second_last_name) REFERENCES ACTOR(FIRST_NAME, MIDDLE_NAME, LAST_NAME, SECOND_LAST_NAME) ,
ADD CONSTRAINT AM_MOVIE
FOREIGN KEY (Movie_Original_name) REFERENCES MOVIE(Original_name);