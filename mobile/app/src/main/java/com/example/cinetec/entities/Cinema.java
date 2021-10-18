package com.example.cinetec.entities;

public class Cinema {
    String Cinema_name;

    /**
     * get the cinema name
     * @return String cinema name
     */
    public String getCinema_name() {
        return Cinema_name;
    }

    /**
     * set cinema name
     * @param cinema_name String cinema name
     */
    public void setCinema_name(String cinema_name) {
        Cinema_name = cinema_name;
    }

    /**
     * Class constructor
     * @param cinema_name
     */
    public Cinema(String cinema_name) {
        Cinema_name = cinema_name;
    }



}
