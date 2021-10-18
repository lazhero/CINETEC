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
    int Columns;

    /**
     * gets the Projection id
     * @return int projection id
     */
    public int getId() {
        return Id;
    }

    /**
     * set the project id
     * @param id int projection id
     */
    public void setId(int id) {
        Id = id;
    }

    /**
     * gets the cinema name
     * @return String cinema name
     */
    public String getCinema_name() {
        return Cinema_name;
    }

    /**
     * Sets ciname name
     * @param cinema_name String name
     *
     */
    public void setCinema_name(String cinema_name) {
        Cinema_name = cinema_name;
    }

    /**
     * gets the Projection Room Number
     * @return  int room number
     */
    public int getRoom_Number() {
        return Room_Number;
    }

    /**
     * set room number
     * @param room_Number int room number
     */
    public void setRoom_Number(int room_Number) {
        Room_Number = room_Number;
    }

    /**
     * returns the movie original name
     * @return
     */
    public String getMovie_original_name() {
        return Movie_original_name;
    }

    /**
     * Sets the movie original name
     * @param movie_original_name
     */
    public void setMovie_original_name(String movie_original_name) {
        Movie_original_name = movie_original_name;
    }

    /**
     * gets data
     * @return   String date
     */
    public String getDate() {
        return Date;
    }

    /**
     * Set date
     * @param date  String date
     */
    public void setDate(String date) {
        Date = date;
    }

    /**
     * returns date
     * @return String date
     */
    public String getInitial_time() {
        return Initial_time;
    }

    /**
     * set initial date
     * @param initial_time
     */
    public void setInitial_time(String initial_time) {
        Initial_time = initial_time;
    }


    /**
     * Class constructor
     * @param id    int ID
     * @param cinema_name   String cinema name
     * @param room_Number   int Room number
     * @param movie_original_name   String movie original name
     * @param date  String date
     * @param initial_time  String initial time
     * @param Columns   int number of columns
     */
    public Projection(int id, String cinema_name, int room_Number, String movie_original_name,String date, String initial_time,int Columns) {
        Id = id;
        Cinema_name = cinema_name;
        Room_Number = room_Number;
        Movie_original_name = movie_original_name;
        Date = date;
        Initial_time = initial_time;
        this.Columns=Columns;
    }

    @Override
    public String toString() {
        return "Projection{" +
                "Id=" + Id +
                ", Cinema_name='" + Cinema_name + '\'' +
                ", Room_Number=" + Room_Number +
                ", Movie_original_name='" + Movie_original_name + '\'' +
                ", Date='" + Date + '\'' +
                ", Initial_time='" + Initial_time + '\'' +
                ", Columns=" + Columns +
                '}';
    }
}
