package com.example.cinetec.entities;

public class Seat {
    private int Projection_id;
    private int Number;
    private int State;

    /**
     * get the projection id
     * @return  int projection id
     */
    public int getProjection_id() {
        return Projection_id;
    }

    /**
     * set projection id
     * @param projection_id int projection id
     */
    public void setProjection_id(int projection_id) {
        Projection_id = projection_id;
    }

    /**
     * get Seat number
     * @return  int seat number
     */
    public int getNumber() {
        return Number;
    }

    /**
     * set the seat number
     * @param number    int number
     */
    public void setNumber(int number) {
        Number = number;
    }

    /**
     * return the seat state
     * @return
     */
    public int getState() {
        return State;
    }

    /**
     * set the seat state
     * @param state int state
     */

    public void setState(int state) {
        State = state;
    }

    /**
     * Class constructor
     * @param projection_id int Projection id
     * @param number    int seat number
     * @param state int seat state
     */
    public Seat(int projection_id, int number, int state) {
        Projection_id = projection_id;
        Number = number;
        State = state;
    }
}
