package com.example.cinetec.entities;

import java.sql.Date;
import java.sql.Time;

public class Projection {
    int Id;
    String Cinema_name;
    int Room_Number;
    String Movie_original_name;
    String Date;
    String Initial_time;

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getCinema_name() {
        return Cinema_name;
    }

    public void setCinema_name(String cinema_name) {
        Cinema_name = cinema_name;
    }

    public int getRoom_Number() {
        return Room_Number;
    }

    public void setRoom_Number(int room_Number) {
        Room_Number = room_Number;
    }

    public String getMovie_original_name() {
        return Movie_original_name;
    }

    public void setMovie_original_name(String movie_original_name) {
        Movie_original_name = movie_original_name;
    }

    public String getDate() {
        return Date;
    }

    public void setDate(String date) {
        Date = date;
    }

    public String getInitial_time() {
        return Initial_time;
    }

    public void setInitial_time(String initial_time) {
        Initial_time = initial_time;
    }



    public Projection(int id, String cinema_name, int room_Number, String movie_original_name,String date, String initial_time) {
        Id = id;
        Cinema_name = cinema_name;
        Room_Number = room_Number;
        Movie_original_name = movie_original_name;
        Date = date;
        Initial_time = initial_time;
    }
}
