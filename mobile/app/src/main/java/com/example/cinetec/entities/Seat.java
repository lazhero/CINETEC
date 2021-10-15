package com.example.cinetec.entities;

public class Seat {
    private int Projection_id;
    private int Number;
    private int State;

    public int getProjection_id() {
        return Projection_id;
    }

    public void setProjection_id(int projection_id) {
        Projection_id = projection_id;
    }

    public int getNumber() {
        return Number;
    }

    public void setNumber(int number) {
        Number = number;
    }

    public int getState() {
        return State;
    }

    public void setState(int state) {
        State = state;
    }

    public Seat(int projection_id, int number, int state) {
        Projection_id = projection_id;
        Number = number;
        State = state;
    }
}
