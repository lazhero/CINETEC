package com.example.cinetec.state;

import java.util.ArrayList;

public class State {
    private static State Instance;
    private String Cinema_name;
    private String Movie_original_name;
    private int Projection_id;
    private String username;
    private ArrayList<Integer> seats;

    public ArrayList<Integer> getSeats() {
        return seats;
    }

    public void setSeats(ArrayList<Integer> seats) {
        this.seats = seats;
    }

    private State(){

    }
    public static State getInstance(){
        if(Instance==null){
            Instance=new State();
        }
        return Instance;
    }
    public String getCinema_name() {
        return Cinema_name;
    }

    public void setCinema_name(String cinema_name) {
        Cinema_name = cinema_name;
    }

    public String getMovie_original_name() {
        return Movie_original_name;
    }

    public void setMovie_original_name(String movie_original_name) {
        Movie_original_name = movie_original_name;
    }

    public int getProjection_id() {
        return Projection_id;
    }

    public void setProjection_id(int projection_id) {
        Projection_id = projection_id;
    }
    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
