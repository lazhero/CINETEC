package com.example.cinetec.entities;

public class Movie {
    String Original_name;
    String Name;
    String Image;

    /**
     * get the movie original name
     * @return String movie orginal name
     */
    public String getOriginal_name() {
        return Original_name;
    }

    /**
     * set original name
     * @param original_name String orginal name
     */
    public void setOriginal_name(String original_name) {
        Original_name = original_name;
    }

    /**
     * Gets the movie name
     * @return String name
     */
    public String getName() {
        return Name;
    }

    /**
     * Sets movie name
     * @param name String name
     */
    public void setName(String name) {
        Name = name;
    }

    /**
     * String returns the image route
     * @return
     */
    public String getImage() {
        return Image;
    }

    /**
     * set the image url
     * @param image String image url
     */
    public void setImage(String image) {
        Image = image;
    }

    /**
     * Class constructor
     * @param original_name String original name
     * @param name  String name
     * @param image String image url
     */
    public Movie(String original_name, String name, String image) {
        Original_name = original_name;
        Name = name;
        Image = image;
    }
}
